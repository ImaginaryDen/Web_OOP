using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.StorageEntries
{
	public class TablEntry : Entry
	{
		List<List<string>> Tabl;

		TablEntry()
		{
			Type = "Edit_Tabl_Entry";
		}
	}
}
