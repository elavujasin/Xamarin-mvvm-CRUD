using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Cars_app.Model
{
  public class CarModel
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Registration { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
