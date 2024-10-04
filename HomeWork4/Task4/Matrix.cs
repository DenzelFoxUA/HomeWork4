using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeWork4
{
    public class Matrix : IEnumerable<int>
    {
        public int Rows { get; private set; } = 0;
        public int Columns { get; private set; } = 0;

        private int[,] _matrix;

        public string Name { get; init; }
        public int this[int i, int j]
        {
            get => _matrix[i, j];
            set => _matrix[i, j] = value;
        }

        public Matrix()
        {
            Name = "DEF";
            _matrix = new int[Rows,Columns];
            GenerateNumbersInMatrix(0);
        }

        public Matrix(int rows, int columns, string name, int minValueInMatrix = 0, int maxValueInMatrix = 9)
        {
            Rows = rows;
            Columns = columns;
            Name = name;
            _matrix = new int[Rows, Columns];
            GenerateNumbersInMatrix(minValueInMatrix, maxValueInMatrix);
        }

        public override string ToString()
        {
            string matrix = string.Empty;
            for(int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    matrix += _matrix[i, j] + "\t";
                }
                matrix += "\n";
            }

            return $"{Name}:\n" +
                $"{matrix}";
        }

        private void GenerateNumbersInMatrix(int min, int max)
        {
            Random rand = new Random();
            for(int i = 0; i < Rows; i++)
            {
                for(int j = 0; j < Columns; j++)
                {
                    _matrix[i, j] = rand.Next(min, max);
                }
            }
        }

        private void GenerateNumbersInMatrix(int putSameValue)
        {

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    _matrix[i, j] = putSameValue;
                }
            }
        }

        //equals виконує один с принципів додавання чи віднімання матриць - кількість стовпців
        //і рядків повинна бути однакова
        public override bool Equals(object? obj)
        {
            var _B = obj as Matrix;

            if(_B is not null)
                return Rows == _B.Rows && Columns == _B.Columns;

            else return false;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for(int i = 0; i < Rows; i++)
            {
                for(int j = 0; j < Columns; j++)
                {
                    yield return _matrix[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _matrix.GetEnumerator();
        }


        //оператор == виконує роль індикатора виконання основного принципу множення 2х матириць
        // кількість стовпців матриці А повинно дорівнювати кільскості рядків матриці Б
        public static bool operator == (Matrix _A, Matrix _B)
        {
            if (_A is not null && _B is not null)
                return _A.Columns == _B.Rows;
            else
                return false;
        }

        public static bool operator !=(Matrix _A, Matrix _B) => !(_A == _B);

        public static Matrix operator * (Matrix _A, int multiplyer)
        {

            if (_A is not null)
            {
                Matrix result = new Matrix(_A.Rows, _A.Columns, $"{multiplyer}{_A.Name}");
                for (int i = 0; i < _A.Rows; i++)
                {
                    for (int j = 0; j < _A.Columns; j++)
                    {
                        result[i,j] = _A[i, j] * multiplyer;
                    }
                }

                return result;
            }
            else
                return new Matrix();

            
        }

        public static Matrix operator * (Matrix _A, Matrix _B)
        {
            if (_A is not null && _B is not null && _A == _B) //тут використовується оператор ==
            {
                Matrix result = new Matrix(_A.Rows, _B.Columns, $"{_A.Name} X {_B.Name}");

                for (int i = 0; i < _A.Rows; i++)
                {
                    for (int j = 0; j < _B.Columns; j++)
                    {
                        int temp = 0;
                        for (int k = 0; k < _A.Columns; k++)
                        {
                            temp += _A[i, k] * _B[k, j];
                        }
                       result[i, j] = temp;
                    }
                }

                return result;
            }
            else
                return new Matrix(); ;
        }

        public static Matrix operator + (Matrix _A, Matrix _B)
        {
            if (_A.Equals(_B))
            {
                Matrix _C = new Matrix(_A.Rows, _A.Columns, $"{_A.Name}+{_B.Name}");
                for (int i = 0; i < _A.Rows; i++)
                {
                    for (int j = 0; j < _A.Columns; j++)
                    {
                        _C[i, j] = _A[i, j] + _B[i, j];
                    }
                }
                return _C;
            }
            else
                return new Matrix();
        }

        public static Matrix operator - (Matrix _A, Matrix _B)
        {

            if (_A.Equals(_B))
            {
                Matrix _C = new Matrix(_A.Rows, _A.Columns, $"{_A.Name}-{_B.Name}");
                for (int i = 0; i < _A.Rows; i++)
                {
                    for (int j = 0; j < _A.Columns; j++)
                    {
                        _C[i, j] = _A[i, j] - _B[i, j];
                    }
                }
                return _C;
            }
            else
                return new Matrix();
        }

        public override int GetHashCode()
        {
            int buffer = 0;

            for(int i = 0; i < Rows; i++)
            {
                for(int j = 0; j < Columns; j++)
                {
                    buffer += _matrix[i, j];
                }
            }

            return buffer.GetHashCode();
        }
    }
}
