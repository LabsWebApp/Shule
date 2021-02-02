/*
 * Библиотека, работающая с GC
 */
//02.02.2021
using System;

namespace UseGC
{
    /// <summary>
    /// "Секундомер" памяти
    /// </summary>
    public class MemoryStopwatch
    {
        /// <summary>
        /// Счётчик байтов
        /// </summary>
        private long _total;

        /// <summary>
        /// Стартует секундомер
        /// </summary>
        public void Start()
        {
            GC.Collect();
            _total = GC.GetTotalMemory(true);
        }

        //!!!!!!!!!МЕТОД НЕ КОРРЕКТЕН - force ДОЛЖЕН БЫТЬ ВСЕГДА false
        /// <summary>
        /// Остановка секундомера
        /// </summary>
        /// <param name="force">нужно ли ждать очистку памяти. по умолчанию false</param>
        /// <returns>изменение памяти в байтах от старта</returns>
        public long Next(bool force = false) => GC.GetTotalMemory(force) - _total;
    }
}
