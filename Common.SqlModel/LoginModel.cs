using System.ComponentModel.DataAnnotations;

namespace Common.SqlModel
{
    public class LoginModel
    {
        [Display(Name = "账号")]
        [MaxLength(50)]
        [Required(ErrorMessage = "账号不能为空")]
        public string UserNo { get; set; }
        [MaxLength(50)]
        [Display(Name = "密码")]
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }
        [MaxLength(6)]
        [Display(Name = "验证码")]
        [Required(ErrorMessage = "验证码不能为空")]
        public string VerificationCode { get; set; } = "HLIMSA";
        [Required(ErrorMessage = "参数不完整")]
        /// <summary>
        /// 2020.06.12增加验证码
        /// </summary>
        public string UUID { get; set; } = "HLIMSA";
    }
}
