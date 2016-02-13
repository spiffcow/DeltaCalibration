using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbeDataToCommands
{
    // taken from dc42's delta wizard: http://escher3d.com/pages/wizards/wizarddelta.php
    struct PointError
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double ZError { get; private set; }

        public PointError(double x, double y, double zError)
        {
            X = x;
            Y = y;
            ZError = zError;
        }
    }

    class Delta
    {
        private const double degreesToRadians = Math.PI / 180.0;
        private double[] towerX;
        private double[] towerY;
        private double coreFa;
        private double coreFb;
        private double coreFc;

        public double diagonal { get; private set; }
        public double homedHeight { get; private set; }
        public double radius { get; private set; }
        public double xadj { get; private set; }
        public double xstop { get; private set; }
        public double yadj { get; private set; }
        public double ystop { get; private set; }
        public double zadj { get; private set; }
        public double zstop { get; private set; }
        public double homedCarriageHeight { get; private set; }
        public double Xab { get; private set; }
        public double Xbc { get; private set; }
        public double Xca { get; private set; }
        public double Yab { get; private set; }
        public double Ybc { get; private set; }
        public double Yca { get; private set; }
        public double Q { get; private set; }
        public double Q2 { get; private set; }
        public double D2 { get; private set; }

        public Delta(double diagonal, double radius, double height, double xstop, double ystop, double zstop, double xadj, double yadj, double zadj)
        {
            this.diagonal = diagonal;
            this.radius = radius;
            this.homedHeight = height;
            this.xstop = xstop;
            this.ystop = ystop;
            this.zstop = zstop;
            this.xadj = xadj;
            this.yadj = yadj;
            this.zadj = zadj;
            this.Recalc();
        }

        private void Recalc()
        {
            this.towerX = new double[]
            {
                -(this.radius * Math.Cos((30 + this.xadj) * degreesToRadians)),
                (this.radius * Math.Cos((30 - this.yadj) * degreesToRadians)),
                -(this.radius * Math.Sin(this.zadj * degreesToRadians))
            };
            this.towerY = new double[]
            {
                -(this.radius * Math.Sin((30 + this.xadj) * degreesToRadians)),
                -(this.radius * Math.Sin((30 - this.yadj) * degreesToRadians)),
                (this.radius * Math.Cos(this.zadj * degreesToRadians))
            };

            this.Xbc = this.towerX[2] - this.towerX[1];
            this.Xca = this.towerX[0] - this.towerX[2];
            this.Xab = this.towerX[1] - this.towerX[0];
            this.Ybc = this.towerY[2] - this.towerY[1];
            this.Yca = this.towerY[0] - this.towerY[2];
            this.Yab = this.towerY[1] - this.towerY[0];
            this.coreFa = FSquare(this.towerX[0]) + FSquare(this.towerY[0]);
            this.coreFb = FSquare(this.towerX[1]) + FSquare(this.towerY[1]);
            this.coreFc = FSquare(this.towerX[2]) + FSquare(this.towerY[2]);
            this.Q = 2 * (this.Xca * this.Yab - this.Xab * this.Yca);
            this.Q2 = FSquare(this.Q);
            this.D2 = FSquare(this.diagonal);

            // Calculate the base carriage height when the printer is homed.
            var tempHeight = this.diagonal;     // any sensible height will do here, probably even zero
            this.homedCarriageHeight = this.homedHeight + tempHeight - this.InverseTransform(tempHeight, tempHeight, tempHeight);
        }

        private double InverseTransform(double Ha, double Hb, double Hc)
        {
            var Fa = this.coreFa + FSquare(Ha);
            var Fb = this.coreFb + FSquare(Hb);
            var Fc = this.coreFc + FSquare(Hc);

            // Setup PQRSU such that x = -(S - uz)/P, y = (P - Rz)/Q
            var P = (this.Xbc * Fa) + (this.Xca * Fb) + (this.Xab * Fc);
            var S = (this.Ybc * Fa) + (this.Yca * Fb) + (this.Yab * Fc);

            var R = 2 * ((this.Xbc * Ha) + (this.Xca * Hb) + (this.Xab * Hc));
            var U = 2 * ((this.Ybc * Ha) + (this.Yca * Hb) + (this.Yab * Hc));

            var R2 = FSquare(R);
            var U2 = FSquare(U);

            var A = U2 + R2 + this.Q2;
            var minusHalfB = S * U + P * R + Ha * this.Q2 + this.towerX[0] * U * this.Q - this.towerY[0] * R * this.Q;
            var C = FSquare(S + this.towerX[0] * this.Q) + FSquare(P - this.towerY[0] * this.Q) + (FSquare(Ha) - this.D2) * this.Q2;

            var rslt = (minusHalfB - Math.Sqrt(FSquare(minusHalfB) - A * C)) / A;
            if (rslt.Equals(double.NaN))
                throw new ArgumentException("At least one probe point is not reachable. Please correct your delta radius, diagonal rod length, or probe coordniates.");

            return rslt;
        }

        private double FSquare(double v)
        {
            return Math.Pow(v, 2);
        }

        private double ComputeDerivative(int deriv, double ha, double hb, double hc)
        {
            var perturb = 0.2;          // perturbation amount in mm or degrees
            var hiParams = new Delta(this.diagonal, this.radius, this.homedHeight, this.xstop, this.ystop, this.zstop, this.xadj, this.yadj, this.zadj);
            var loParams = new Delta(this.diagonal, this.radius, this.homedHeight, this.xstop, this.ystop, this.zstop, this.xadj, this.yadj, this.zadj);
            switch (deriv)
            {
                case 0:
                case 1:
                case 2:
                    break;

                case 3:
                    hiParams.radius += perturb;
                    loParams.radius -= perturb;
                    break;

                case 4:
                    hiParams.xadj += perturb;
                    loParams.xadj -= perturb;
                    break;

                case 5:
                    hiParams.yadj += perturb;
                    loParams.yadj -= perturb;
                    break;

                case 6:
                    hiParams.diagonal += perturb;
                    loParams.diagonal -= perturb;
                    break;
            }

            hiParams.Recalc();
            loParams.Recalc();

            var zHi = hiParams.InverseTransform((deriv == 0) ? ha + perturb : ha, (deriv == 1) ? hb + perturb : hb, (deriv == 2) ? hc + perturb : hc);
            var zLo = loParams.InverseTransform((deriv == 0) ? ha - perturb : ha, (deriv == 1) ? hb - perturb : hb, (deriv == 2) ? hc - perturb : hc);

            return (zHi - zLo) / (2 * perturb);
        }

        private void NormaliseEndstopAdjustments()
        {
            var eav = Math.Min(this.xstop, Math.Min(this.ystop, this.zstop));
            this.xstop -= eav;
            this.ystop -= eav;
            this.zstop -= eav;
            this.homedHeight += eav;
            this.homedCarriageHeight += eav;				// no need for a full recalc, this is sufficient
        }

        private void Adjust(int numFactors, double[] v, bool norm)
        {
            var oldCarriageHeightA = this.homedCarriageHeight + this.xstop; // save for later

            // Update endstop adjustments
            this.xstop += v[0];
            this.ystop += v[1];
            this.zstop += v[2];
            if (norm)
            {
                this.NormaliseEndstopAdjustments();
            }

            if (numFactors >= 4)
            {
                this.radius += v[3];

                if (numFactors >= 6)
                {
                    this.xadj += v[4];
                    this.yadj += v[5];

                    if (numFactors == 7)
                    {
                        this.diagonal += v[6];
                    }
                }

                this.Recalc();
            }

            // Adjusting the diagonal and the tower positions affects the homed carriage height.
            // We need to adjust homedHeight to allow for this, to get the change that was requested in the endstop corrections.
            var heightError = this.homedCarriageHeight + this.xstop - oldCarriageHeightA - v[0];
            this.homedHeight -= heightError;
            this.homedCarriageHeight -= heightError;
        }

        public double Transform(double[] machinePos, int axis)
        {
            return machinePos[2] + Math.Sqrt(this.D2 - FSquare(machinePos[0] - this.towerX[axis]) - FSquare(machinePos[1] - this.towerY[axis]));
        }

        private double[] GaussJordan(ref double[,] matrix, int numRows)
        {
            for (var i = 0; i < numRows; ++i)
            {
                // Swap the rows around for stable Gauss-Jordan elimination
                var vmax = Math.Abs(matrix[i, i]);
                for (var j = i + 1; j < numRows; ++j)
                {
                    var rmax = Math.Abs(matrix[j,i]);
                    if (rmax > vmax)
                    {
                        SwapRows(ref matrix, i, j);
                        vmax = rmax;
                    }
                }

                // Use row i to eliminate the ith element from previous and subsequent rows
                var v = matrix[i,i];
                for (var j = 0; j < i; ++j)
                {
                    var factor = matrix[j,i] / v;
                    matrix[j,i] = 0.0;
                    for (var k = i + 1; k <= numRows; ++k)
                    {
                        matrix[j,k] -= matrix[i,k] * factor;
                    }
                }

                for (var j = i + 1; j < numRows; ++j)
                {
                    var factor = matrix[j,i] / v;
                    matrix[j,i] = 0.0;
                    for (var k = i + 1; k <= numRows; ++k)
                    {
                        matrix[j,k] -= matrix[i,k] * factor;
                    }
                }
            }

            var solution = new double[numRows];
            for (var i = 0; i < numRows; ++i)
            {
                solution[i] = (matrix[i,numRows] / matrix[i,i]);
            }
            return solution;
        }

        private void SwapRows(ref double[,] matrix, int i, int j)
        {
            if (i != j)
            {
                for (var k = 0; k < matrix.GetLength(1); ++k)
                {
                    var temp = matrix[i,k];
                    matrix[i,k] = matrix[j,k];
                    matrix[j,k] = temp;
                }
            }
        }

        public Tuple<double,double> DoDeltaCalibration(int numFactors, IList<PointError> zBedProbePoints, bool normalise)
        {
            if (numFactors != 3 && numFactors != 4 && numFactors != 6 && numFactors != 7)
            {
                throw new Exception("Error: " + numFactors + " factors requested but only 3, 4, 6 and 7 supported");
            }
            if (numFactors > zBedProbePoints.Count)
            {
                throw new Exception("Error: need at least as many points as factors you want to calibrate");
            }

            // Transform the probing points to motor endpoints and store them in a matrix, so that we can do multiple iterations using the same data
            var probeMotorPositions = new PointError[zBedProbePoints.Count];
            var corrections = new double[zBedProbePoints.Count];
            var initialSumOfSquares = 0.0;
            for (var i = 0; i < zBedProbePoints.Count; ++i)
            {
                corrections[i] = 0.0;
                var machinePos = new double[3]
                {
                    zBedProbePoints[i].X,
                    zBedProbePoints[i].Y,
                    0
                };

                probeMotorPositions[i] = new PointError(Transform(machinePos, 0), Transform(machinePos, 1), Transform(machinePos, 2));

                initialSumOfSquares += FSquare(zBedProbePoints[i].X) + FSquare(zBedProbePoints[i].Y) + FSquare(zBedProbePoints[i].ZError);
            }

            // remove any erroneous data points..  maybe not the best idea??
            var zip = zBedProbePoints
                .Zip(probeMotorPositions, (point, pos) => new { point, pos })
                .Where(_ => !_.pos.X.Equals(double.NaN) && !_.pos.Y.Equals(double.NaN) && !_.pos.ZError.Equals(double.NaN))
                .ToList();
            zBedProbePoints = (from z in zip select z.point).ToList();
            probeMotorPositions = (from z in zip select z.pos).ToArray();

            // Do 1 or more Newton-Raphson iterations
            var iteration = 0;
            double expectedRmsError;
            for (;;)
            {
                // Build a Nx7 matrix of derivatives with respect to xa, xb, yc, za, zb, zc, diagonal.
                var derivativeMatrix = new double[zBedProbePoints.Count, numFactors];
                for (var i = 0; i < zBedProbePoints.Count; ++i)
                {
                    for (var j = 0; j < numFactors; ++j)
                    {
                        derivativeMatrix[i, j] =
                            ComputeDerivative(j, probeMotorPositions[i].X, probeMotorPositions[i].Y, probeMotorPositions[i].ZError);
                    }
                }

                // Now build the normal equations for least squares fitting
                var normalMatrix = new double[numFactors, numFactors + 1];
                double temp;
                for (var i = 0; i < numFactors; ++i)
                {
                    for (var j = 0; j < numFactors; ++j)
                    {
                        temp = derivativeMatrix[0,i] * derivativeMatrix[0,j];
                        for (var k = 1; k < zBedProbePoints.Count; ++k)
                        {
                            temp += derivativeMatrix[k,i] * derivativeMatrix[k,j];
                        }
                        normalMatrix[i,j] = temp;
                    }
                    temp = derivativeMatrix[0,i] * -(zBedProbePoints[0].ZError + corrections[0]);
                    for (var k = 1; k < zBedProbePoints.Count; ++k)
                    {
                        temp += derivativeMatrix[k,i] * -(zBedProbePoints[k].ZError + corrections[k]);
                    }
                    normalMatrix[i, numFactors] = temp;
                }

                double[] solution = GaussJordan(ref normalMatrix, numFactors);
                if (solution.Any(_ => _.Equals(double.NaN)))
                    throw new Exception("Unable to calculate corrections. Please make sure the bed probe points are all distinct.");
               
                //if (debug)
                //{
                //    DebugPrint(PrintVector("Solution", solution));

                //    // Calculate and display the residuals
                //    var residuals = [];
                //    for (var i = 0; i < numPoints; ++i)
                //    {
                //        var r = zBedProbePoints[i];
                //        for (var j = 0; j < numFactors; ++j)
                //        {
                //            r += solution[j] * derivativeMatrix.data[i][j];
                //        }
                //        residuals.push(r);
                //    }
                //    DebugPrint(PrintVector("Residuals", residuals));
                //}

                Adjust(numFactors, solution, normalise);

                // Calculate the expected probe heights using the new parameters
                {
                    var expectedResiduals = new double[zBedProbePoints.Count];
                    var sumOfSquares = 0.0;
                    for (var i = 0; i < zBedProbePoints.Count; ++i)
                    {
                        probeMotorPositions[i] = new PointError(probeMotorPositions[i].X + solution[0], probeMotorPositions[i].Y + solution[1], probeMotorPositions[i].ZError + solution[2]);
                        var newZ = InverseTransform(probeMotorPositions[i].X, probeMotorPositions[i].Y, probeMotorPositions[i].ZError);
                        corrections[i] = newZ;
                        expectedResiduals[i] = zBedProbePoints[i].ZError + newZ;
                        sumOfSquares += FSquare(expectedResiduals[i]);
                    }

                    expectedRmsError = Math.Sqrt(sumOfSquares / zBedProbePoints.Count);
                }

                // Decide whether to do another iteration Two is slightly better than one, but three doesn't improve things.
                // Alternatively, we could stop when the expected RMS error is only slightly worse than the RMS of the residuals.
                ++iteration;
                if (iteration == 2) { break; }
            }

            return Tuple.Create(Math.Sqrt(initialSumOfSquares / zBedProbePoints.Count), expectedRmsError);
        }
    }
}
