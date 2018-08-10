using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Interfaces;
using ToDoList.Models;

namespace SQLiteApp.Standard.Classes
{
    public class NotesRepository : INotesRepository
    {
        private readonly string _dbPath;

        public NotesRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        private DatabaseContext CreateDatabaseContext()
        {
            return new DatabaseContext(this._dbPath);
        }

        public async Task<IEnumerable<Note>> GetNotesAsync()
        {
            try
            {
                var _databaseContext = CreateDatabaseContext();
                var notes = await _databaseContext.Notes.ToListAsync();
                return notes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Note> GetNoteByIdAsync(int noteId)
        {
            try
            {
                var _databaseContext = CreateDatabaseContext();

                var note = await _databaseContext.Notes.FindAsync(noteId);
                return note;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> AddNoteAsync(Note note)
        {
            try
            {
                var _databaseContext = CreateDatabaseContext();

                var tracking = await _databaseContext.Notes.AddAsync(note);
                await _databaseContext.SaveChangesAsync();
                var isAdded = tracking.State == EntityState.Added;
                return isAdded;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateNoteAsync(Note note)
        {
            try
            {
                var _databaseContext = CreateDatabaseContext();

                var tracking = _databaseContext.Update(note);
                await _databaseContext.SaveChangesAsync();
                var isModified = tracking.State == EntityState.Modified;
                return isModified;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> RemoveNoteAsync(int noteId)
        {
            try
            {
                var _databaseContext = CreateDatabaseContext();

                var note = await _databaseContext.Notes.FirstOrDefaultAsync(x => x.NoteId == noteId);
                var tracking = _databaseContext.Remove(note);
                await _databaseContext.SaveChangesAsync();
                var isDeleted = tracking.State == EntityState.Deleted;
                return isDeleted;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Note>> QueryNoteAsync(Func<Note, bool> predicate)
        {
            try
            {
                var _databaseContext = CreateDatabaseContext();

                var notes = _databaseContext.Notes.Where(predicate);
                return notes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
