using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using ToDoList.Interfaces;
using ToDoList.Models;
using Xamarin.Forms;

namespace ToDoList.ViewModels
{
    public class ToDoListViewModel : INotifyPropertyChanged
    {
        private readonly INotesRepository _notesRepository;

        private IEnumerable<Note> notes;
        public IEnumerable<Note> Notes
        {
            get => notes;
            set {notes = value; OnPropertyChanged(); }
        }

        private string noteId;
        public string NoteId
        {
            get => noteId;
            set { noteId = value; OnPropertyChanged(); }
        }

        private string noteText;
        public string NoteText
        {
            get => noteText;
            set { noteText = value; OnPropertyChanged(); }
        }

        private DateTime noteStart;
        public DateTime NoteStart
        {
            get => noteStart;
            set { noteStart = value; OnPropertyChanged(); }
        }

        private DateTime noteFinish;
        public DateTime NoteFinish
        {
            get => noteFinish;
            set { noteFinish = value; OnPropertyChanged(); }
        }

        public async void AddNote(Note note)
        {
            await _notesRepository.AddNoteAsync(note);
            Notes = await _notesRepository.GetNotesAsync();
        }

        public async void UpdateNote(Note note)
        {
            await _notesRepository.UpdateNoteAsync(note);
            Notes = await _notesRepository.GetNotesAsync();
        }

        public async void RemoveNote(int noteId)
        {
            await _notesRepository.RemoveNoteAsync(noteId);
            Notes = await _notesRepository.GetNotesAsync();
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Notes = await _notesRepository.GetNotesAsync();
                });
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var note = new Note
                    {
                        NoteText = NoteText,
                        NoteDateTimeStart = NoteStart,
                        NoteDateTimeFinish = NoteFinish
                    };
                    SetNull();
                    await _notesRepository.AddNoteAsync(note);
                    Notes = await _notesRepository.GetNotesAsync();
                });
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _notesRepository.RemoveNoteAsync(int.Parse(NoteId));
                    SetNull();
                    Notes = await _notesRepository.GetNotesAsync();
                });
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var note = new Note
                    {
                        NoteId = int.Parse(NoteId),
                        NoteText = NoteText,
                        NoteDateTimeStart = NoteStart,
                        NoteDateTimeFinish = NoteFinish
                    };
                    await _notesRepository.UpdateNoteAsync(note);
                    Notes = await _notesRepository.GetNotesAsync();
                });
            }
        }

        private void SetNull()
        {
            NoteId = null;
            NoteText = null;
            NoteStart = DateTime.Now;
            NoteFinish = DateTime.Now;
        }

        public ToDoListViewModel(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
            Notes = _notesRepository.GetNotesAsync().Result;
            var note = new Note
            {
                NoteText = "test_1",
                NoteDateTimeStart = DateTime.Now,
                NoteDateTimeFinish = DateTime.Now,
            };
            SetNull();
            _notesRepository.AddNoteAsync(note);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
