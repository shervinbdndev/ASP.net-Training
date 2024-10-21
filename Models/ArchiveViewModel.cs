using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Zhenic.Models {
    
    public class ArchiveViewModel {

        [StringLength(50)]
        public required string Title {get;set;}

        public required IFormFile Image {get;set;}

        public required DateTime Date {get;set;}
    }

    public class ArchiveViewModelValidator : AbstractValidator<ArchiveViewModel> {

        public ArchiveViewModelValidator() {

            RuleFor(arch => arch.Title)
            .NotEmpty().WithMessage("فیلد عنوان الزامی است")
            .MaximumLength(50).WithMessage("عنوان نباید بیشتر از 50 کرکتر باشد");

            RuleFor(arch => arch.Image)
            .NotEmpty().WithMessage("بارگذاری تصویر الزامی است")
            .Must(ValidateImage).WithMessage("مجاز هستند jpg & png فقط فایل های با فرمت")
            .Must(ValidateSize).WithMessage("حجم تصویر حداکثر تا 5 مگابایت باشد");

            RuleFor(arch => arch.Date)
            .NotEmpty().WithMessage("تنظیم تاریخ الزامی است");

        }

        private bool ValidateImage(IFormFile file) {

            if (file == null) {
                return false;
            }

            var checkFormat = Path.GetExtension(file.FileName).ToLower();

            return checkFormat == ".jpg" || checkFormat == ".png";
        }

        private bool ValidateSize(IFormFile file) {
            const long MaxSize = 5242880;

            return file.Length <= MaxSize;
        }
    }
}