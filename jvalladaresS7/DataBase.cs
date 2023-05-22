using System;
using System.Collections.Generic;
using System.Text;
using SQLite; //Utilizar los métodos del BDD,

namespace jvalladaresS7
{
    public interface DataBase
    {

        SQLiteAsyncConnection GetConnection(); // Definí el método de conexión 
    }
}
