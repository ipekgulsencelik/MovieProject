using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Movie.Application.Helpers
{
    public static class SlugHelper
    {
        /// <summary>
        /// Verilen metni SEO uyumlu slug formatına çevirir.
        /// Türkçe karakterleri destekler, accent temizler ve güvenli fallback üretir.
        /// </summary>
        public static string ToSlug(string? input, int maxLength = 120)
        {
            if (maxLength < 10) maxLength = 10;

            if (string.IsNullOrWhiteSpace(input))
                return Guid.NewGuid().ToString("N");

            input = input.Trim().ToLowerInvariant();

            // Türkçe karakterleri sadeleştir
            input = input
                .Replace("ğ", "g")
                .Replace("ü", "u")
                .Replace("ş", "s")
                .Replace("ı", "i")
                .Replace("ö", "o")
                .Replace("ç", "c");

            // Accent temizleme (Unicode)
            var normalized = input.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var ch in normalized)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                    sb.Append(ch);
            }

            input = sb.ToString().Normalize(NormalizationForm.FormC);

            // Güvenli karakter seti
            input = Regex.Replace(input, @"[^a-z0-9\s-]", "");
            input = Regex.Replace(input, @"\s+", "-");
            input = Regex.Replace(input, @"-+", "-");

            input = input.Trim('-');

            if (input.Length > maxLength)
                input = input[..maxLength].Trim('-');

            return string.IsNullOrWhiteSpace(input)
                ? Guid.NewGuid().ToString("N")
                : input;
        }
    }
}