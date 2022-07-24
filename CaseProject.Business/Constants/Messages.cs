using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseProject.Business.Constants
{
    public static class Messages
    {
        public static string Added(string fieldName) => $"{fieldName} added successfully";
        public static string FailedAdd(string fieldName) => $"An error occured while adding {fieldName} ";
        public static string Listed(string fieldName) => $"{fieldName} listed successfully";
        public static string Updated(string fieldName) => $"{fieldName} updated successfully.";
        public static string FailedUpdate(string fieldName) => $"An error occured while updating {fieldName}";
        public static string Deleted(string fieldName) => $"{fieldName} deleted successfully.";
        public static string FailedDelete(string fieldName) => $"An error occured while deleting {fieldName}";
        public static string NotFound(string fieldName) => $"{fieldName} not found";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Kullanıcı şifresi yanlış";
        public static string LoginSuccessfully = "Kullanıcı giriş işlemi başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı kayıt işlemi başarıyla gerçekleştirildi";
        public static string AccessTokenCreated = "Kullanıcı tokeni başarıyla oluşturuldu";
        public static string GetUser = "İlgili kullanıcı başarıyla listelenmiştir";
    }
}
