using Agreement.Helpers;
using Agreement.Interfaces;
using Agreement.Models;
using System.Collections.Generic;
using System.Linq;

namespace Agreement.Services
{
    public class ValidatorService : IValidatorService
    {
        public Status ValidateAgreement(AgreementModel agreementModel)
        {
            if (agreementModel == null)
                return new ErrorStatus("Agreement model is null");

            List<string> errors = new List<string>();

            //Validare CNP/CUI
            Status validareCNPCUI = ValidareCNPCUI(agreementModel.CNPCUI);
            if (validareCNPCUI.ResultType != ResultType.Ok)
                errors.AddRange(validareCNPCUI.Errors);

            //Validare Judet
            Status validareJudet = ValidareJudet(agreementModel.Judet);
            if (validareJudet.ResultType != ResultType.Ok)
                errors.AddRange(validareJudet.Errors);

            //Validare nr. Telefon
            Status validareTelefon = ValidareTelefon(agreementModel.NrTelefon);
            if (validareTelefon.ResultType != ResultType.Ok)
                errors.AddRange(validareTelefon.Errors);

            //Validare nume si prenume in caz de CNP.
            Status validareNumePrenume = ValidareNumePrenume(validareCNPCUI, agreementModel.CNPCUI, agreementModel.Nume, agreementModel.Prenume);
            if (validareNumePrenume.ResultType != ResultType.Ok)
                errors.AddRange(validareNumePrenume.Errors);

            //Validare denumire companie in caz de CUI.
            Status validareCompanie = ValidareCompanie(validareCNPCUI, agreementModel.CNPCUI, agreementModel.DenumireCompanie);
            if (validareCompanie.ResultType != ResultType.Ok)
                errors.AddRange(validareCompanie.Errors);

            //Validare email
            Status validareEmail = ValidareEmail(agreementModel.Email);
            if (validareEmail.ResultType != ResultType.Ok)
                errors.AddRange(validareEmail.Errors);

            //Validare acord de prelucrare a datelor cu caracter personal
            Status validareAcordPrelucrareDate = ValidareAcordPrelucrareDate(agreementModel.AcordPrelucrareDate);
            if (validareAcordPrelucrareDate.ResultType != ResultType.Ok)
                errors.AddRange(validareAcordPrelucrareDate.Errors);

            //Validare comunicare email, sms, posta
            if (agreementModel.ComunicareEmail == false && agreementModel.ComunicarePosta==false && agreementModel.ComunicareSMS == false)
                errors.Add("One of Email, SMS, POST must be true");

            if (errors.Any())
                return new ErrorStatus(errors);

            return new OkStatus();
        }
        private Status ValidareJudet(string judet)
        {
            if(judet == null)
            {
                return new ErrorStatus("Judet not set");
            }
            string[] judeteArray = { 
                "AB", "AR", "AG",
                "B", "BC", "BH", "BN", "BT", "BV", "BR", "BZ", 
                "CS", "CL", "CJ", "CT", "CV", 
                "DB", "DJ",
                "GL", "GR", "GJ",
                "HR", "HD",
                "IL", "IS", "IF", 
                "MM", "MH", "MS",
                "NT", 
                "OT",
                "PH",
                "SM", "SJ", "SB", "SV",
                "TR", "TM", "TL",
                "VS", "VL", "VN" };
            HashSet<string> judete = new HashSet<string>(judeteArray);

            if (!judete.Contains(judet.ToUpper()))
                return new ErrorStatus("Judet invalid");
            return new OkStatus();
        }

        private Status ValidareCNPCUI(string uniqueId)
        {

            if (uniqueId == null)
            {
                return new ErrorStatus("CNP/CUI is not set");
            }
            if (uniqueId.Length != 7)
            {
                return new ErrorStatus("CNP/CUI invalid lenght");
            }
            if (!uniqueId.StartsWith("CNP") && !uniqueId.StartsWith("CUI"))
            {
                return new ErrorStatus("CNP/CUI doesn't start with valid prefix (CNP,CUI)");
            }
            if (!uniqueId.Substring(3).All(char.IsDigit))
            {
               return new ErrorStatus("Last 4 characters are not digits");
            }

            return new OkStatus();
        }

        private Status ValidareTelefon(string telefon)
        {
            if(telefon == null) {
                return new ErrorStatus("Number is not set");
            }
            if(!telefon.StartsWith("555"))
            {
                return new ErrorStatus("Number doesn't start with prefix 555 ");
            }
            if (!telefon.Substring(3).All(char.IsDigit))
            {
                return new ErrorStatus("Last 6 characters are not digit");
            }
            return new OkStatus();
        }

        private Status ValidareNumePrenume(Status validareCNPCUI,string uniqueCNP, string nume, string prenume)
        {
            if (validareCNPCUI.ResultType != ResultType.Ok)
                return new OkStatus();

            if (!uniqueCNP.StartsWith("CNP"))
                return new OkStatus();

            if (nume == null) {
                return new ErrorStatus("Nume is not set");
            }
            if (prenume == null)
            {
                return new ErrorStatus("Prenume is not set");
            }

            if (!nume.All(char.IsLetter))
            {
                return new ErrorStatus ("Nume contains other symbols");
            }
            if (!prenume.All(char.IsLetter))
            {
                return new ErrorStatus("Prenume contains other symbols");
            }

            return new OkStatus();
        }

        private Status ValidareCompanie(Status validareCNPCUI, string uniqueCUI, string companie)
        {
            if (validareCNPCUI.ResultType != ResultType.Ok)
                return new OkStatus();

            if (!uniqueCUI.StartsWith("CUI"))
                return new OkStatus();

            if (companie == null)
                return new ErrorStatus("DenumireCompanie is not set");

            return new OkStatus();
        }

       private Status ValidareEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address != email)
                    return new ErrorStatus("Email invalid");
                return new OkStatus();
            }
            catch
            {
                return new ErrorStatus("Email invalid");
            }
        }

        private Status ValidareAcordPrelucrareDate(bool gdpr)
        {
            if(gdpr == false)
            {
                return new ErrorStatus("Acord Prelucrare date must be true");
            }
            return new OkStatus();

        }

    }
}
