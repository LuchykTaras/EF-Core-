using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hogwartz_App.Models
{
    /// <summary>
    /// Клас-сутність для відображення результатів SQL-подання vw_WizardWands.
    /// Використовує атрибут [Keyless], оскільки подання не має первинного ключа і призначене лише для читання.
    /// </summary>
    [Keyless]
    [Table("vw_WizardWands")] // Зв'язує цей клас із конкретним поданням у базі даних
    public class WizardWandInfo
    {
        /// <summary>
        /// Ім'я чарівника (з таблиці Wizards)
        /// </summary>
        public string WizardName { get; set; } = null!;

        /// <summary>
        /// Факультет чарівника (з таблиці Wizards)
        /// </summary>
        public string House { get; set; } = null!;

        /// <summary>
        /// Матеріал чарівної палички (з таблиці Wands). 
        /// Тип string? (nullable), бо у чарівника може не бути палички (LEFT JOIN)
        /// </summary>
        public string? WandMaterial { get; set; }
    }
}