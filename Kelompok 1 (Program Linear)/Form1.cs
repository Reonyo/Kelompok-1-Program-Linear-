using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kelompok_1__Program_Linear_
{
    public partial class form_main : Form
    {
        int jumlah_variabel, jumlah_constraint,kolom,baris;
        string[] variabel_basis,variabel_nonbasis;
        double[,] A, B_invers,c_B,c,b;

        List<IterationResult> iterationResults = new List<IterationResult>();
        public form_main()
        {
            InitializeComponent();
        }

        private void btn_generatetable_Click(object sender, EventArgs e)
        {
            try
            {
                jumlah_variabel = int.Parse(txtbox_jumlahvariabel.Text);
                jumlah_constraint = int.Parse(txtbox_jumlahconstraint.Text);
                GenerateTable();
            }
            catch (FormatException)
            {
                MessageBox.Show("Input tidak valid. Silakan masukkan bilangan bulat yang valid.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            //Initialisasi Array
            c = new double[1,jumlah_variabel];
            A = new double[jumlah_constraint, jumlah_variabel];
            b = new double[jumlah_constraint,1];
            c_B = new double[1,jumlah_constraint];
            variabel_basis = new string[jumlah_constraint];
            variabel_nonbasis = new string[jumlah_variabel];
            B_invers = new double[jumlah_constraint,jumlah_constraint];

            //Assign Array
            try 
            {
                // Assign values for c array (Z row)
                for (int i = 1; i <= jumlah_variabel; i++)
                {
                    c[0,i - 1] = Convert.ToDouble(datagrid_userinput.Rows[0].Cells[i].Value);
                }

                // Assign values for A array (constraint rows)
                for (int i = 1; i <= jumlah_constraint; i++)
                {
                    for (int j = 1; j <= jumlah_variabel; j++)
                    {
                        A[i - 1, j - 1] = Convert.ToDouble(datagrid_userinput.Rows[i].Cells[j].Value);
                    }
                }

                // Assign values for b array (RHS)
                for (int i = 1; i <= jumlah_constraint; i++)
                {
                    b[i - 1,0] = Convert.ToDouble(datagrid_userinput.Rows[i].Cells[datagrid_userinput.ColumnCount - 1].Value);
                }

                // Assign values for variabel_basis
                string[] variabel_basis = new string[jumlah_constraint];
                for (int i = 0; i < jumlah_constraint; i++)
                {
                    variabel_basis[i] = "s" + (i + 1);
                }

                // Assign values for variabel_nonbasis
                string[] variabel_nonbasis = new string[jumlah_variabel];
                for (int i = 0; i < jumlah_variabel; i++)
                {
                    variabel_nonbasis[i] = "x" + (i + 1);
                }

                // Assign B_invers sebagai matrix identitas
                for (int i = 0; i < jumlah_constraint; i++)
                {
                    for (int j = 0; j < jumlah_constraint; j++)
                    {
                        B_invers[i, j] = (i == j) ? 1.0 : 0.0;
                    }
                }

                // Langkah Awal selesai..
                // Lanjut Uji Optimalitas pertama
                double[] minus_c;
                int minNegativeindex=-1;
                double minNegativeValue = double.MaxValue;
                minus_c = new double[jumlah_variabel];
                for (int i = 0; i < jumlah_variabel; i++)
                {
                    minus_c[i] = -c[0,i];
                    if (minus_c[i] < 0 && minus_c[i]<minNegativeValue)
                    {
                        minNegativeValue = minus_c[i];
                        minNegativeindex = i;
                    }
                }
                if(minNegativeindex==-1)
                {
                    // Sudah Optimal
                    return;
                }
                // Kolom dengan index minNegativeIndex menjadi pivot
                kolom = minNegativeindex+1;

            }
            catch (FormatException)
            {
                MessageBox.Show("Input tidak valid. Silakan masukkan bilangan bulat yang valid.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            Iteration();
        }
        private void Iteration()
        {
            MessageBox.Show("Iterasi");
            string var_masuk, var_keluar;
            double[] a,rasio,miu;
            a = new double[jumlah_constraint];
            rasio = new double[jumlah_constraint];
            miu = new double[jumlah_constraint];

            A = MultiplyMatrices(B_invers, A);
            TampilkanMatrix(A, "A");
            b = MultiplyMatrices(B_invers, b);
            TampilkanMatrix(b, "B");

            for (int i = 0;i<jumlah_constraint;i++)
            {
                a[i] = A[i, kolom-1];
                MessageBox.Show($"nilai a ke-{i}= {a[i]}");
            }

            //Variabel Masuk
            if(kolom==-1)
            {
                MessageBox.Show("The problem is unbounded");
                return;
            }
            var_masuk = variabel_nonbasis[kolom-1];
           
            for(int i = 0;i<jumlah_constraint;i++)
            {
                if (a[i]==0)
                {
                    rasio[i] = 0;
                }
                else
                {
                    rasio[i] = (b[i,0] / a[i]);
                }
                MessageBox.Show($"nilai rasio ke-{i}= {rasio[i]}");
            }
            //Sekarang pilih nilai terkecil tak negatif/tak nol
            baris = -1;
            double minNegativeValue = double.MaxValue;
            for(int i = 0;i<jumlah_constraint;i++)
            {
                if (rasio[i] > 0 && rasio[i] < minNegativeValue)
                {
                    minNegativeValue = rasio[i];
                    baris = i+1;
                }
            }
            if(baris==-1)
            {
                MessageBox.Show("The problem is infeasible");
                return;
            }
            //Variabel Keluar (r = baris)
            var_keluar = variabel_basis[baris];

            //Edit Nilai variabel_basis dan variabel_nonbasis
            variabel_basis[baris-1] = var_masuk;
            for(int i = 0;i<jumlah_constraint;i++)
            {
                MessageBox.Show($"Basis ke-{i} adalah {variabel_basis[i]}");
            }
            variabel_nonbasis[kolom-1] = var_keluar;
            for (int i = 0; i < jumlah_variabel; i++)
            {
                MessageBox.Show($"Basis ke-{i} adalah {variabel_nonbasis[i]}");
            }
            c_B[0,baris-1] = c[0,kolom-1];

            //Menentukan B_invers baru
            for(int i =1;i<=jumlah_constraint;i++)
            {
                if(i==baris)
                {
                    miu[i-1] = 1 / (A[baris-1,kolom-1]);
                }
                else
                {
                    miu[i-1] = -A[i-1, kolom-1] / A[baris-1, kolom-1];
                }
            }
            double[,] E;
            E = new double[jumlah_constraint,jumlah_constraint];
            for (int i = 0; i < jumlah_constraint; i++)
            {
                for (int j = 0; j < jumlah_constraint; j++)
                {
                    if(j==baris-1)
                    {
                        E[i, j] = miu[i];
                    }
                    else if(i==j)
                    {
                        E[i, j] = 1;
                    }
                    else
                    {
                        E[i, j] = 0;
                    }
                }
            }
            //B_invers baru
            B_invers = MultiplyMatrices(E, B_invers);
            TampilkanMatrix(B_invers, "B_invers");

            //Uji optimalitas
            bool optimal;
            optimal = UjiOptimal();

            //Save tabel
            SaveIterationResult();

            //Rekursif
            if (optimal == false)
            {
                MessageBox.Show("Iterasi 1 Berhasil!");
                Iteration();
            }
            MessageBox.Show("Selesai!");
        }
        static double[,] SubtractMatrices(double[,] matrixA, double[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int colsB = matrixB.GetLength(1);

            // Check if matrices have the same dimensions
            if (rowsA != rowsB || colsA != colsB)
            {
                Console.WriteLine("Gagal kurang");
                throw new ArgumentException("Matrices must have the same dimensions for subtraction.");
            }

            // Initialize the result matrix
            double[,] resultMatrix = new double[rowsA, colsA];

            // Perform matrix subtraction
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    resultMatrix[i, j] = matrixA[i, j] - matrixB[i, j];
                }
            }

            return resultMatrix;
        }
        private void TampilkanMatrix(double[,] matrix,string judul)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                   MessageBox.Show($"{judul} baris ke-{i} Kolom ke-{j} = {matrix[i,j]}");
                }
            }
        }
        private bool UjiOptimal()
        {
            // Get the latest iteration result
            IterationResult latestResult = iterationResults.LastOrDefault();

            if (latestResult != null)
            {
                // Check the type of variables in the non-basis
                bool isSVariable = latestResult.variabel_nonbasis.Any(variable => variable.StartsWith("s"));

                // Get the matrices from the latest iteration
                double[,] C_B = latestResult.c_B;
                double[,] B_invers = latestResult.B_invers;
                double[,] A = GetLatestA(); // Implement a method to get the latest A matrix

                // Perform the optimality test based on the type of variables in the non-basis
                if (isSVariable)
                {
                    // For non-basis with variables "s1, s2, s3"
                    double[,] testMatrix = MultiplyMatrices(C_B, B_invers);
                    return !testMatrix.Cast<double>().Any(value => value < 0);
                }
                else
                {
                    // For non-basis with variables "x1, x2, ..."
                    double[,] testMatrix = MultiplyMatrices(C_B, B_invers);
                    testMatrix = MultiplyMatrices(testMatrix, A);
                    return !testMatrix.Cast<double>().Any(value => value < 0);
                }
            }

            return false; // Default to not optimal if there are no iteration results
        }

        // Assuming you have a method to get the latest A matrix from the iteration results
        private double[,] GetLatestA()
        {
            IterationResult latestResult = iterationResults.LastOrDefault();
            return latestResult?.A;
        }

        private double[,] MultiplyMatrices(double[,] matrixA, double[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int colsB = matrixB.GetLength(1);

            // Check if matrices can be multiplied
            if (colsA != rowsB)
            {
                Console.WriteLine("Gagal kali");
                throw new ArgumentException("Invalid matrix dimensions for multiplication.");
            }

            // Initialize the result matrix
            double[,] resultMatrix = new double[rowsA, colsB];

            // Perform matrix multiplication
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        sum += matrixA[i, k] * matrixB[k, j];
                    }
                    resultMatrix[i, j] = sum;
                }
            }

            return resultMatrix;
        }
        private void GenerateTable()
        {
            // Clear existing columns and rows
            datagrid_userinput.Columns.Clear();
            datagrid_userinput.Rows.Clear();

            // Create the column headers
            List<string> columnHeaders = new List<string> { "Basis" };
            for (int i = 1; i <= jumlah_variabel; i++)
            {
                columnHeaders.Add("x" + i);
            }
            columnHeaders.Add("sign");
            columnHeaders.Add("RHS");

            // Manually add columns to the DataGridView
            foreach (string header in columnHeaders)
            {
                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                column.HeaderText = header;

                // Set specific columns as read-only
                if (header == "Basis" || header == "sign")
                {
                    column.ReadOnly = true;
                }
                column.Width = 40;
                datagrid_userinput.Columns.Add(column);
            }

            // Create Z row
            DataGridViewRow zRow = new DataGridViewRow();
            zRow.CreateCells(datagrid_userinput);
            zRow.Cells[0].Value = "Z";
            zRow.Cells[zRow.Cells.Count - 2].ReadOnly=true;
            zRow.Cells[zRow.Cells.Count - 1].ReadOnly=true;

            datagrid_userinput.Rows.Add(zRow);

            // Create constraint rows
            for (int i = 1; i <= jumlah_constraint; i++)
            {
                DataGridViewRow constraintRow = new DataGridViewRow();
                constraintRow.CreateCells(datagrid_userinput);
                constraintRow.Cells[0].Value = "c" + i;
                constraintRow.Cells[constraintRow.Cells.Count - 2].Value = "<=";
                constraintRow.Cells[constraintRow.Cells.Count - 1].Value = 0;

                datagrid_userinput.Rows.Add(constraintRow);
            }
        }

        private void SaveIterationResult()
        {
            // Create a new IterationResult object and add it to the list
            IterationResult result = new IterationResult
            {
                B_invers = CopyMatrix(B_invers),
                c_B = CopyMatrix(c_B),
                variabel_basis = variabel_basis.Clone() as string[],
                variabel_nonbasis = variabel_nonbasis.Clone() as string[],
                kolom = kolom,
                baris = baris
            };

            iterationResults.Add(result);
        }

        // Helper method to create a deep copy of a matrix
        private double[,] CopyMatrix(double[,] original)
        {
            int rows = original.GetLength(0);
            int cols = original.GetLength(1);

            double[,] copy = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    copy[i, j] = original[i, j];
                }
            }

            return copy;
        }

        // Helper class to represent the state of the linear program at a specific iteration
        private class IterationResult
        {
            public double[,] B_invers { get; set; }
            public double[,] c_B { get; set; }
            public string[] variabel_basis { get; set; }
            public string[] variabel_nonbasis { get; set; }
            public int kolom { get; set; }
            public int baris { get; set; }
            public double[,] A { get; set; }
        }
    }
}
