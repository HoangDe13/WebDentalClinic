using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDentalClinic.Models
{
    public class CheckItem
    {
        public LICHHEN _lichhen { get; set; }
        public string _check { get; set; }
    }

    public class Check
    {
        List<CheckItem> items = new List<CheckItem>();
        public IEnumerable<CheckItem> Items
        {
            get { return items; }
        }
        public void Change_Status(LICHHEN _lich, string _chech = "DXN")
        {
            var item = Items.FirstOrDefault(s => s._lichhen.MaLichHen == _lich.MaLichHen);
            if (item == null)
            {
                items.Add(new CheckItem
                {
                    _lichhen = _lich,
                    _check = _chech
                });
            }
            else
                item._check = _chech;
        }
        public void Update_lich(int id, string _new_check)
        {
            var item = items.Find(s => s._lichhen.MaLichHen == id);
            if (item != null)
                item._check += _new_check;
        }
    }
}