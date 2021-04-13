using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DynamicArrayLibrary
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>, ICloneable
    {
        private T[] _array;

        /// <summary>
        /// Свойство Length — получение количества элементов.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Свойство Capacity — получение ёмкости: длины внутреннего массива.
        /// </summary>
        public int Capacity { get => _array.Length; }

        /// <summary>
        /// Конструктор без параметров (создаётся массив ёмкостью 8 элементов).
        /// </summary>
        public DynamicArray()
        {
            _array = new T[8];
            Length = 0;
        }

        /// <summary>
        /// Конструктор с одним целочисленным параметром (создаётся массив указанной ёмкости).
        /// </summary>
        public DynamicArray(int capacity)
        {
            _array = new T[capacity];
            Length = 0;
        }

        /// <summary>
        /// Конструктор, который в качестве параметра принимает коллекцию, реализующую интерфейс
        /// IEnumerable<T>, создаёт массив нужного размера и копирует в него все элементы из коллекции.
        /// </summary>
        public DynamicArray(IEnumerable<T> source)
        {
            _array = source.ToArray();
            Length = _array.Length;
        }

        /// <summary>
        /// Метод Add, добавляющий в конец массива один элемент. При нехватке места
        /// для добавления элемента, ёмкость массива должна удваиваться.
        /// </summary>
        public void Add(T value)
        {
            IncreaseCapacity(Length + 1);
            _array[Length] = value;
            Length += 1;
        }

        /// <summary>
        /// Метод, увеличивающий емкость массива на 1 элемент
        /// или в 2 раза при превышении имеющейся емкости.
        /// Вызывается при добавлени элементов в массив.
        /// </summary>
        private void IncreaseCapacity(int value)
        {
            if (value <= Capacity)
            {
                return;
            }

            int newCapacity = Length * 2;
            T[] newArray = new T[newCapacity];
            Array.Copy(_array, newArray, Length);
            _array = newArray;
        }

        /// <summary>
        /// Метод AddRange, добавляющий в конец массива содержимое коллекции, реализующей
        /// интерфейс IEnumerable<T>.Обратите внимание, метод должен корректно учитывать число
        /// элементов в коллекции с тем, чтобы при необходимости расширения массива делать это
        /// только один раз вне зависимости от числа элементов в добавляемой коллекции.
        /// </summary>
        public void AddRange(IEnumerable<T> source)
        {
            T[] sourceArray = source.ToArray();

            IncreaseCapacity(Length + sourceArray.Length);
            Array.Copy(sourceArray, 0, _array, Length, sourceArray.Length);
            Length += sourceArray.Length;
        }

        /// <summary>
        /// Метод Remove, удаляющий из коллекции указанный элемент. Метод должен возвращать
        /// true, если удаление прошло успешно и false в противном случае. При удалении элементов
        /// реальная ёмкость массива не должна уменьшаться.
        /// </summary>
        public bool Remove(T value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i].Equals(value))
                {
                    LeftOffset(i + 1, 1);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Для удаления элементов массива проивзодится смещение элементов влево.
        /// Смещение с позиции position влево на количество элементов, заданное numberOfPos.
        /// </summary>
        private void LeftOffset(int position, int numberOfPos)
        {
            int insertPosition;
            if (position - numberOfPos < 0)
            {
                insertPosition = 0;
                position += numberOfPos;
            }
            else
            {
                insertPosition = position - numberOfPos;
            }

            Array.Copy(_array, position, _array, insertPosition, Length - position);
            Length -= numberOfPos;
        }

        /// <summary>
        /// Метод Insert, позволяющий добавить элемент в произвольную позицию массива (обратите
        /// внимание, может потребоваться расширить массив). Метод должен возвращать true, если
        /// добавление прошло успешно и false в противном случае. При выходе за границу массива
        /// должно генерироваться исключение ArgumentOutOfRangeException.
        /// </summary>
        public bool Insert(int index, T item)
        {
            if (index < 0 || index > Length)
                throw new ArgumentOutOfRangeException();

            RightOffset(index, 1);
            _array[index] = item;
            return true;
        }

        /// <summary>
        /// Метод для смещения элементов массива вправо.
        /// Смещение с позиции position вправо на количество элементов, заданное numberOfPos.
        /// Увеличивает емкость массива, если нужно.
        /// </summary>
        private void RightOffset(int position, int numberOfPos)
        {
            IncreaseCapacity(Length + numberOfPos);

            Array.Copy(_array, position, _array, position + numberOfPos, Length - position);
            Length += numberOfPos;

            // filling empty spaces with default values
            Array.Fill(_array, default, position, numberOfPos);
        }

        /// <summary>
        /// Метод, реализующий интерфейс IEnumerable.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();

        /// <summary>
        /// Метод, реализующий интерфейс IEnumerable<T>.
        /// </summary>
        public virtual IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _array[i];
            }
        }

        /// <summary>
        /// Индексатор, позволяющий работать с элементом с указанным номером. При выходе за
        /// границу массива должно генерироваться исключение ArgumentOutOfRangeException.
        /// + 1*. Доступ к элементам с конца при использовании отрицательного индекса (−1: последний,
        /// −2: предпоследний и т.д.).
        /// </summary>
        public T this[int index]
        {
            get
            {
                index = ResolveIndex(index);

                return _array[index];
            }
            set
            {
                index = ResolveIndex(index);

                _array[index] = value;
            }
        }

        /// <summary>
        /// Метод, возвращающий корректный индекс или генерирующий исключение
        /// при входных данных, выходящих за границу массива.
        /// Работает с условием 1*.
        /// </summary>
        private int ResolveIndex(int index)
        {
            if (index >= Length || index < 0 - Length)
                throw new ArgumentOutOfRangeException();
            if (index >= 0)
            {
                return index;
            }
            else
            {
                return index + Length;
            }
        }

        /// <summary>
        /// Возможность ручного изменения значения Capacity с сохранением уцелевших данных
        /// (данные за пределами новой Capacity сохранять не нужно).
        /// </summary>
        public void SetCapacity(int newCapacity)
        {
            if (newCapacity < 0)
                throw new ArgumentException("Capacity must be greater than 0");
            if (Capacity == newCapacity)
                return;

            T[] newArray = new T[newCapacity];
            int newLength = Length > newCapacity ? newCapacity : Length;

            Array.Copy(_array, newArray, newLength);

            Length = newLength;
            _array = newArray;
        }


        /// <summary>
        /// Реализовать интерфейс ICloneable для создания копии массива.
        /// </summary>
        public object Clone()
        {
            DynamicArray<T> clone = new DynamicArray<T>(Capacity);
            clone.AddRange(this);

            return clone;
        }

        /// <summary>
        /// Добавить метод ToArray, возвращающий новый массив (обычный), содержащий все
        /// содержащиеся в текущем динамическом массиве объекты.
        /// </summary>
        public T[] ToArray()
        {
            T[] newArray = new T[Length];

            Array.Copy(_array, newArray, Length);

            return newArray;
        }
    }
}
