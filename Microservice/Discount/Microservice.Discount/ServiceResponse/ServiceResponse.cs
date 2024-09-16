namespace Microservice.Discount.ServiceResponse
{
    namespace MultiShop.Catalog.ServiceResponse
    {
        public class ServiceResponse<Tkey>
        {
            public string Message { get; set; } = string.Empty;

            public bool Success { get; set; } = false;

            public int StatusCode { get; set; } = 500;

            public Tkey? Data { get; set; }

            public void SetError(string message, int? statusCode = 500)
            {
                Success = false;
                StatusCode = statusCode ?? 500;
                Message = message;
            }

            public void SetErrorPreRegister(string additionalMessage = "", string defaultMessage = "Bu veri önceden kayıtlıdır", int? statusCode = 500)
            {
                Success = false;
                StatusCode = statusCode ?? 500;
                Message = string.IsNullOrEmpty(additionalMessage) ? defaultMessage : $"{defaultMessage} - {additionalMessage}";
            }

            public void SetErrorUpdateNotId(string message = "Update işlemi için Id'si olmayan istek gönderilemez", int? statusCode = 500)
            {
                Success = false;
                StatusCode = statusCode ?? 500;
                Message = message;
            }

            public void SetErrorUpdate(string message = "", int? statusCode = 500)
            {
                SetError("Kayıt güncellenemedi => " + message, statusCode);
            }
            public void SetRecordCouldNotFound(string? message = "")
            {
                SetError("Kayit bulunamadı !" + (message == "" ? "" : (" // " + message)));
            }

            public void SetRecordCouldNotWith404Found(string? message = "")
            {
                SetError("Kayit bulunamadı !" + (message == "" ? "" : (" // " + message)), 404);
            }

            public void SetRecordFounded(Tkey? data)
            {
                SetSuccess(data, "Kayıt(lar) başarıyla çekildi");
            }
            public void SetErrorNoAccessPermission(string? message = "Erişim izniniz yok", int? statusCode = 300)
            {
                Success = false;
                StatusCode = statusCode ?? 300;
                Message = message ?? "Erişim izniniz yok";
            }

            public void SetSuccess(Tkey? data, string message = "", int? statusCode = 200)
            {
                Success = true;
                StatusCode = statusCode ?? 200;
                Message = Message == string.Empty ? message : Message + " - " + message;
                Data = data;
            }
            public void SetSuccessNoData(string message = "İşlem Başarılı", int? statusCode = 200)
            {
                Success = true;
                StatusCode = statusCode ?? 200;
                Message = Message == string.Empty ? message : Message + " - " + message;
            }
            public void SetSuccessCreateNoData(string message = "Kayıt başarıyla oluşturuldu", int? statusCode = 200)
            {
                Success = true;
                StatusCode = statusCode ?? 200;
                Message = Message == string.Empty ? message : Message + " - " + message;
            }
            public void SetSuccessUpdateNoData(string message = "Kayıt başarıyla güncellendi", int? statusCode = 200)
            {
                Success = true;
                StatusCode = statusCode ?? 200;
                Message = Message == string.Empty ? message : Message + " - " + message;
            }
            public void SetSuccessList(Tkey? data, string message = "", int? statusCode = 200)
            {
                SetSuccess(data, "Liste başarıyla döndürüldü");
            }

            public void SetSuccessUpdate(Tkey? data = default, string message = "", int? statusCode = 200)
            {
                Success = true;
                StatusCode = statusCode ?? 200;
                Message = "Kayıt başarıyla güncellendi";
                Data = data;
            }

            public void SetSuccesCreate(Tkey? data = default, string message = "", int? statusCode = 200)
            {
                Success = true;
                StatusCode = statusCode ?? 200;
                Message = "Kayıt başarıyla oluşturuldu";
                Data = data;
            }
            public void SetSuccesDelete(Tkey? data = default, string message = "Kayıt başarıyla silindi", int? statusCode = 200)
            {
                Success = true;
                StatusCode = statusCode ?? 200;
                Message = message;
                Data = data;
            }


            public void SetErrorCreate(string message = "", int? statusCode = 500)
            {
                Success = false;
                StatusCode = statusCode ?? 500;
                Message = "Kayıt oluşturulamadı => " + message;
            }

            public void SetErrorDelete(string message = "", int? statusCode = 500)
            {
                Success = false;
                StatusCode = statusCode ?? 500;
                Message = "Kayıt silinemedi => " + message;
            }
        }
    }
}