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


            string validareCNPCUI = ValidateCNPCUI(agreementModel.CNPCUI);

            if (validareCNPCUI != "ok")
                errors.Add(validareCNPCUI);

            string validareJudet = ValidateJudet(agreementModel.Judet);

            if (validareJudet != "ok")
                errors.Add(validareJudet);


            if (!errors.Any()) return new SuccessResult<AgreementModel>(agreementModel);
            return new BadRequestResult<AgreementModel>(errors);
        }
        private string ValidateJudet(string judet)
        {
            if(judet == null)
            {
                return "Judet not set";
            }
            string[] judeteArray = { "AB ", " AR ", " AG ", " BC ", " BH ", " BN ", " BT ", " BV ", " BR ", " BZ ", " CS ", " CL ", " CJ ", " CT ", " CV ", " DB ", " DJ ", " GL ", " GR ", " GJ ", " HR ", " HD ", " IL ", " IS ", " IF ", " MM ", " MH ", " MS ", " NT ", " OT ", " PH ", " SM ", " SJ ", " SB ", " SV ", " TR ", " TM ", " TL ", " VS ", " VL ", " VN" };
            HashSet<string> judete = new HashSet<string>(judeteArray);

            if (!judete.Contains(judet.ToUpper()))
                return "Judet invalid";
            return "ok";
        }

        private string ValidateCNPCUI(string uniqueId)
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
    }
}
