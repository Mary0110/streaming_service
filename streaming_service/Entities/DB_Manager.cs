using System.Data;
using MySqlConnector;

namespace streaming_service.Entities;

public class DB_Manager
{
    public static MySqlCommand getCommand()
    {
        var connection =
            new MySqlConnection("Server=localhost; Port=3306; Database=streaming_service; Username=root;Allow User Variables=True");
        connection.Open();
        var command = new MySqlCommand();
        command.Connection = connection;
        command.CommandType = CommandType.Text;
        return command;
    }
}

