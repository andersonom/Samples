using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MVPSampleBLL.Interface
{
    public interface IFood
    {
        DataSet BindGrid { set; }

        string NameFood { get; }

        string Price { get; }

        string Description { get; }

        string Calories { get; }

        string XMLFilePath { get; set; }
    }
}
