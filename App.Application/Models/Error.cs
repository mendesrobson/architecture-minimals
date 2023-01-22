using App.Application.Enums;

namespace App.Application.Models;

public class Error
{
    public ErroCode Code { get; set; }
    public string Message { get; set; }
}
