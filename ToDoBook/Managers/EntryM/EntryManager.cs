using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoBook.Storage.Entity;
using ToDoBook.Storage;

namespace ToDoBook.Managers.EntryM
{
	public class EntryManager
	{
		WorkContext _context;

		public EntryManager(WorkContext context)
		{
			_context = context;
		}

		public List<Entry> GetEntries(int IdDiary)
		{
			List<Entry> entry = new List<Entry>();

			foreach (var item in _context.Entries.ToList().Where(x => x.DiaryID == IdDiary))
			{
				switch (item.Type)
				{
					case 1:
						entry.Add(_context.TextEntries.Find(item.EntryID));
						break;
					case 2:
						entry.Add(_context.MitingEntries.Find(item.EntryID));
						break;
					case 5:
						entry.Add(_context.Images.Find(item.EntryID));
						break;
				}
			}

			return entry;
		}

		public void AddEntry(TextEntry entry, int IdDiary)
		{
			entry.Type = "Edit_Text_Entry";
			_context.TextEntries.Add(entry);
			_context.SaveChanges();
			_context.Entries.Add(new EntriesBelonging { Type = 1, EntryID =
				_context.TextEntries.ToList().Last().ID, DiaryID = IdDiary });
			_context.SaveChanges();
		}

		public void AddEntry(MitingEntry entry, int IdDiary)
		{
			entry.Type = "Edit_Miting_Entry";
			_context.MitingEntries.Add(entry);
			_context.SaveChanges();
			_context.Entries.Add(new EntriesBelonging { Type = 2, EntryID =
				_context.MitingEntries.ToList().Last().ID, DiaryID = IdDiary });
			_context.SaveChanges();
		}

		public void AddEntry(ImageEntry entry, int IdDiary)
		{
			entry.Type = "Edit_Image_Entry";
			_context.Images.Add(entry);
			_context.SaveChanges();
			_context.Entries.Add(new EntriesBelonging
			{
				Type = 5,
				EntryID =
				_context.Images.ToList().Last().ID,
				DiaryID = IdDiary
			});
			_context.SaveChanges();
		}

		public WorkContext GetContext() => _context;
	}
}
