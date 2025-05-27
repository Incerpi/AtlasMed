using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public static class CpfValidator
{
    public static ValidationResult IsValid(string cpf, ValidationContext context)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return new ValidationResult("CPF é obrigatório.");

        cpf = Regex.Replace(cpf, @"[^\d]", ""); // Remove pontos e traços

        if (cpf.Length != 11 || !Regex.IsMatch(cpf, @"^\d{11}$"))
            return new ValidationResult("CPF deve conter 11 dígitos.");

        // Verifica se todos os dígitos são iguais
        if (new string(cpf[0], 11) == cpf)
            return new ValidationResult("CPF inválido.");

        // Valida dígitos
        for (int j = 9; j < 11; j++)
        {
            int soma = 0;
            for (int i = 0; i < j; i++)
                soma += (cpf[i] - '0') * (j + 1 - i);

            int resto = (soma * 10) % 11;
            if (resto == 10) resto = 0;

            if (resto != (cpf[j] - '0'))
                return new ValidationResult("CPF inválido.");
        }

        return ValidationResult.Success;
    }
}