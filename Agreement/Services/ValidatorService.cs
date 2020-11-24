using Agreement.Helpers;
using Agreement.Interfaces;
using Agreement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.Services
{
    public class ValidatorService : IValidatorService
    {
        public Result<AgreementModel> ValidateAgreement(AgreementModel agreementModel)
        {
            if (agreementModel == null)
                return new BadRequestResult<AgreementModel>("Agreement model is null");

            List<string> errors = new List<string>();

            //Validare CNP/CUI
            string validareCNPCUI = ValidareCNPCUI(agreementModel.CNPCUI);
            if (validareCNPCUI != "ok")
                errors.Add(validareCNPCUI);

            //Validare Judet
            string validareJudet = ValidareJudet(agreementModel.Judet);
            if (validareJudet != "ok")
                errors.Add(validareJudet);

            //Validare nr. Telefon
            string validareTelefon = ValidareTelefon(agreementModel.NrTelefon);
            if (validareTelefon != "ok")
                errors.Add(validareTelefon);

            //Validare nume si prenume in caz de CNP.
            string validareNumePrenume = ValidareNumePrenume(validareCNPCUI, agreementModel.CNPCUI, agreementModel.Nume, agreementModel.Prenume);
            if (validareNumePrenume != "ok")
                errors.Add(validareNumePrenume);

            //Validare denumire companie in caz de CUI.
            string validareCompanie = ValidareCompanie(validareCNPCUI, agreementModel.CNPCUI, agreementModel.DenumireCompanie);
            if (validareCompanie != "ok")
                errors.Add(validareCompanie);

            //Validare email
            string validareEmail = ValidareEmail(agreementModel.Email);
            if (validareEmail != "ok")
                errors.Add(validareEmail);

            //Validare acord de prelucrare a datelor cu caracter personal
            string validareAcordPrelucrareDate = ValidareAcordPrelucrareDate(agreementModel.AcordPrelucrareDate);
            if (validareAcordPrelucrareDate != "ok")
                errors.Add(validareAcordPrelucrareDate);

            //Validare comunicare email, sms, posta
            if (agreementModel.ComunicareEmail == false && agreementModel.ComunicarePosta==false && agreementModel.ComunicareSMS == false)
                errors.Add("One of Email, SMS, POST must be true");

            if (errors.Any())
                return new BadRequestResult<AgreementModel>(errors);

            return new SuccessResult<AgreementModel>(agreementModel);
        }
        private string ValidareJudet(string judet)
        {
            if(judet == null)
            {
                return "Judet not set";
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
                return "Judet invalid";
            return "ok";
        }

        private string ValidareCNPCUI(string uniqueId)
        {

            if (uniqueId == null)
            {
                return "CNP/CUI is not set";
            }
            if (uniqueId.Length != 7)
            {
                return "CNP/CUI invalid lenght";
            }
            if (!uniqueId.StartsWith("CNP") && !uniqueId.StartsWith("CUI"))
            {
                return "CNP/CUI doesn't start with valid prefix (CNP,CUI)";
            }
            if (!uniqueId.Substring(3).All(char.IsDigit))
            {
               return "Last 4 characters are not digits";
            }

            return "ok";
        }

        private string ValidareTelefon(string telefon)
        {
            if(telefon == null)
            {
                return "Number is not set";
            }
            if(!telefon.StartsWith("555"))
            {
                return "Number doesn't start with prefix 555 ";
            }
            if (!telefon.Substring(3).All(char.IsDigit))
            {
                return "Last 6 characters are not digit";
            }
            return "ok";
        }

        private string ValidareNumePrenume(string validareCNPCUI,string uniqueCNP, string nume, string prenume)
        {
            if (validareCNPCUI != "ok")
                return "ok";

            if (!uniqueCNP.StartsWith("CNP"))
                return "ok";
            if (nume == null)
            {
                return "Nume is not set";
            }
            if (prenume == null)
            {
                return "Prenume is not set";
            }

            if (!nume.All(char.IsLetter))
            {
                return "Nume contains other symbols";
            }
            if (!prenume.All(char.IsLetter))
            {
                return "Prenume contains other symbols";
            }

            return "ok";
        }
        
        private string ValidareCompanie(string validareCNPCUI, string uniqueCUI, string companie)
        {
            if (validareCNPCUI != "ok")
                return "ok";

            if (!uniqueCUI.StartsWith("CUI"))
                return "ok";

            if (companie == null)
                return "DenumireCompanie is not set";

            return "ok";
        }

       private string ValidareEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email ? "ok" : "Email invalid";
            }
            catch
            {
                return "Email invalid";
            }
        }

        private string ValidareAcordPrelucrareDate(bool gdpr)
        {
            if(gdpr == false)
            {
                return "Acord Prelucrare date must be true";
            }
            return "ok";

        }

    }
}
