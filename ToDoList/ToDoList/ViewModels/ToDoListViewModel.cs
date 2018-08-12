using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using ToDoList.Controls.MasterDetail.Views;
using ToDoList.Interfaces;
using ToDoList.Models;
using Xamarin.Forms;

namespace ToDoList.ViewModels
{
    public class ToDoListViewModel : BaseViewModel
    {
        private readonly INotesRepository NotesRepository;

        private IEnumerable<Note> notes;
        public IEnumerable<Note> Notes
        {
            get => notes;
            set {notes = value; OnPropertyChanged(); }
        }

        public ToDoListViewModel(INotesRepository _notesRepository)
        {
            NotesRepository = _notesRepository;
            Notes = NotesRepository.GetNotesAsync().Result;
            MessagingCenter.Subscribe<NewToDoPage, Note>(this, "AddCommand", async (obj, note) =>
            {
                var _note = note as Note;
                await NotesRepository.AddNoteAsync(_note);
                Notes = NotesRepository.GetNotesAsync().Result;
            });
            MessagingCenter.Subscribe<DetailToDoPage, Note>(this, "UpdateCommand", async (obj, note) =>
            {
                var _note = note as Note;
                await NotesRepository.UpdateNoteAsync(_note);
                Notes = NotesRepository.GetNotesAsync().Result;
            });
            MessagingCenter.Subscribe<DetailToDoPage, int>(this, "RemoveCommand", async (obj, noteId) =>
            {
                await NotesRepository.RemoveNoteAsync(noteId);
                Notes = NotesRepository.GetNotesAsync().Result;
            });
        }
    }
}
