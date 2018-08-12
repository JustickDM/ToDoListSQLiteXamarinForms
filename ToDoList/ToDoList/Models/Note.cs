using System;

namespace ToDoList.Models
{
    /// <summary>
    /// Запись.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Номер.
        /// </summary>
        public int NoteId { get; set; }

        /// <summary>
        /// Текст.
        /// </summary>
        public string NoteText { get; set; }

    }
}
