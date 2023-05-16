using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawDigits
{
    public class DrawSymbolsClass : Control
    {
        private const int matrixRows = 28;
        private const int matrixColumns = 28;

        private int[,] _DATA_MATRIX = new int[matrixRows, matrixColumns];

        private bool _isDrawMode;

        private const int standart_Field_Size = 224;
        private const int draw_mode_Field_Size = 448;

        private int _currentFieldSize;

        public int[,] DATA_MATRIX
        {
            get { return _DATA_MATRIX; }
            set { _DATA_MATRIX = value; }
        }

        public int currentPixelSize;

        public bool IsDrawMode
        {
            get
            {
                return _isDrawMode;
            }
            set
            {
                if (_isDrawMode != value)
                {
                    _isDrawMode = value;
                    if (IsDrawMode)
                    {
                        _currentFieldSize = draw_mode_Field_Size;
                        Height = draw_mode_Field_Size;
                        Width = draw_mode_Field_Size;
                    }
                    else
                    {
                        _currentFieldSize = standart_Field_Size;
                        Height = standart_Field_Size;
                        Width = standart_Field_Size;
                    }
                    currentPixelSize = _currentFieldSize / _DATA_MATRIX.GetLength(0);
                    Invalidate();
                }
            }
        }

        public DrawSymbolsClass() : base()
        {
            _currentFieldSize = standart_Field_Size;
            _isDrawMode = false;
            currentPixelSize = _currentFieldSize / _DATA_MATRIX.GetLength(0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush pixelColor = null;
            for (int i = 0; i < DATA_MATRIX.GetLength(0); i++)
            {
                for (int j = 0; j < DATA_MATRIX.GetLength(1); j++)
                {
                    pixelColor = new SolidBrush(Color.FromArgb(DATA_MATRIX[i, j], DATA_MATRIX[i, j], DATA_MATRIX[i, j]));
                    e.Graphics.FillRectangle(pixelColor, 0 + currentPixelSize * j, 0 + currentPixelSize * i, currentPixelSize, currentPixelSize);
                }
            }
            pixelColor.Dispose();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = 0x02000000;
                return cp;
            }
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, height, specified);
            Width = width;
            Height = height;
            Invalidate();
        }

        public void DownloadSymbolToMatrix(string[] row)
        {
            int i, j = 0;

            for (int k = 1; k < row.Length; k++)
            {
                i = (k - 1) / _DATA_MATRIX.GetLength(1);
                j = (k - 1) - i * _DATA_MATRIX.GetLength(0);

                _DATA_MATRIX[i, j] = int.Parse(row[k]);
            }
            NormalizeMatrix();
        }

        public void ErasePicture()
        {
            for (int i = 0; i < DATA_MATRIX.GetLength(0); i++)
            {
                for (int j = 0; j < DATA_MATRIX.GetLength(1); j++)
                {
                    DATA_MATRIX[i, j] = 0;
                }
            }
            Invalidate();
        }

        public void DrawPixel(int row, int col)
        {
            if (row > DATA_MATRIX.GetLength(0) - 1)
            {
                row = DATA_MATRIX.GetLength(0) - 1;
            }
            if (row < 0)
            {
                row = 0;
            }
            if (col > DATA_MATRIX.GetLength(0) - 1)
            {
                col = DATA_MATRIX.GetLength(0) - 1;
            }
            if (col < 0)
            {
                col = 0;
            }
            DATA_MATRIX[row, col] = 255;
            Invalidate();
        }

        public void NormalizeMatrix()
        {
            TurnRightMatrix();
            ReflectMatrix();
            Invalidate();
        }

        private void TurnRightMatrix()
        {
            int n = DATA_MATRIX.GetLength(0);
            int buf = 0;
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    buf = DATA_MATRIX[i, j];
                    DATA_MATRIX[i, j] = DATA_MATRIX[n - 1 - j, i];
                    DATA_MATRIX[n - 1 - j, i] = DATA_MATRIX[n - 1 - i, n - 1 - j];
                    DATA_MATRIX[n - 1 - i, n - 1 - j] = DATA_MATRIX[j, n - 1 - i];
                    DATA_MATRIX[j, n - 1 - i] = buf;
                }
            }
        }
        private void ReflectMatrix()
        {
            int n = DATA_MATRIX.GetLength(0);
            int buf = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    buf = DATA_MATRIX[i, j];
                    DATA_MATRIX[i, j] = DATA_MATRIX[i, n - 1 - j];
                    DATA_MATRIX[i, n - 1 - j] = buf;
                }
            }
        }
    }
}
