﻿namespace ApiRest.DTO;

public class UsuarioDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Nss { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}