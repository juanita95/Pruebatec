using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webmvcapi.Models;
using MongoDB.Driver;
using Webmvcapi.Controllers;
using System.Net.Mail;

namespace Webmvcapi.Services
{
    public class UserService
    {
        private readonly IMongoCollection<users> _users;


        public void sendEmail(string destiny)
        {
            string EmailOrigen = "aatemonis@gmail.com";
            string EmailDestino = destiny;
            string EmailContraseña = "JUANITA611";
            MailMessage correo = new MailMessage(EmailOrigen, EmailDestino, "Reporte Facturas", "Estimado usuario le informamos que su factura esta proxima a cambiar de estado");

            correo.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, EmailContraseña);

            smtpClient.Send(correo);
            smtpClient.Dispose();

        }

        public UserService(IFacturasSettings settings)
        {
            var cliente = new MongoClient("mongodb://localhost:27017");
            var database = cliente.GetDatabase("Facturas");

            _users = database.GetCollection<users>("users");


        }

        public List<users> Get() =>
            _users.Find(user => true).ToList();


        public users Get(string Id) =>
            _users.Find<users>(user => user.Id == Id).FirstOrDefault();
       

        public users Create(users user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string Id, users userIn)
        {

            _users.ReplaceOne(user => user.Id == Id, userIn);
        }
        

        
        

        public void Remove(users userIn) =>
            _users.DeleteOne(user => userIn.Id == userIn.Id);

        public void Remove(string Id) =>
            _users.DeleteOne(user => user.Id == Id);

    }
}
