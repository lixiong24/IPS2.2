using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 邮件发送类，定义了发送邮件的属性和方法。通过MailKit实现。
	/// </summary>
	public class MailSender
    {
		#region 属性
		private string m_FromName;
		/// <summary>
		/// 发送人名称
		/// </summary>
		public string FromName
		{
			get
			{
				return this.m_FromName;
			}
			set
			{
				this.m_FromName = value;
			}
		}

		private string m_Subject;
		/// <summary>
		/// 邮件的主题
		/// </summary>
		public string Subject
		{
			get
			{
				return this.m_Subject;
			}
			set
			{
				this.m_Subject = value;
			}
		}

		private string m_MailBody;
		/// <summary>
		/// 邮件的正文
		/// </summary>
		public string MailBody
		{
			get
			{
				return this.m_MailBody;
			}
			set
			{
				this.m_MailBody = value;
			}
		}

		private bool m_IsBodyHtml;
		/// <summary>
		/// 邮件正文是否为HTML格式
		/// </summary>
		public bool IsBodyHtml
		{
			get
			{
				return this.m_IsBodyHtml;
			}
			set
			{
				this.m_IsBodyHtml = value;
			}
		}

		private string m_AttachmentFilePath;
		/// <summary>
		/// 邮件的附件文件地址
		/// </summary>
		public string AttachmentFilePath
		{
			get
			{
				return this.m_AttachmentFilePath;
			}
			set
			{
				this.m_AttachmentFilePath = value;
			}
		}

		private string m_Msg;
		/// <summary>
		/// 发送邮件出错后返回的邮件状态信息
		/// </summary>
		public string Msg
		{
			get
			{
				return this.m_Msg;
			}
			set
			{
				this.m_Msg = value;
			}
		}

		private IList<MailboxAddress> m_MailToAddressList = new List<MailboxAddress>();
		/// <summary>
		/// 收件人地址集合
		/// </summary>
		public IList<MailboxAddress> MailToAddressList
		{
			get
			{
				if (this.m_MailToAddressList == null)
				{
					this.m_MailToAddressList = new List<MailboxAddress>();
				}
				return this.m_MailToAddressList;
			}
			set
			{
				this.m_MailToAddressList = value;
			}
		}

		private IList<MailboxAddress> m_MailCopyToAddressList = new List<MailboxAddress>();
		/// <summary>
		/// 抄送收件人地址集合
		/// </summary>
		public IList<MailboxAddress> MailCopyToAddressList
		{
			get
			{
				if (this.m_MailCopyToAddressList == null)
				{
					this.m_MailCopyToAddressList = new List<MailboxAddress>();
				}
				return this.m_MailCopyToAddressList;
			}
			set
			{
				this.m_MailCopyToAddressList = value;
			}
		}

		private MailboxAddress m_ReplyTo;
		/// <summary>
		/// 回复地址
		/// </summary>
		public MailboxAddress ReplyTo
		{
			get
			{
				return this.m_ReplyTo;
			}
			set
			{
				this.m_ReplyTo = value;
			}
		}

		private MessagePriority m_Priority;
		/// <summary>
		/// 邮件的优先级
		/// </summary>
		public MessagePriority Priority
		{
			get
			{
				return this.m_Priority;
			}
			set
			{
				this.m_Priority = value;
			}
		}
		#endregion

		/// <summary>
		/// 得到邮件状态对应的文本信息
		/// </summary>
		/// <param name="mailcode">自定义邮件状态</param>
		/// <returns>邮件状态信息</returns>
		public static string GetMailStateInfo(MailState mailcode)
		{
			switch (mailcode)
			{
				case MailState.NoMailToAddress:
					return "没有可发送的信箱地址";

				case MailState.NoSubject:
					return "没有邮件题标";

				case MailState.FileNotFind:
					return "找不到要上传的文件";

				case MailState.MailConfigIsNullOrEmpty:
					return "邮箱配置错误";

				case MailState.SendFailure:
					return "发送不成功";

				case MailState.ConfigFileIsWriteOnly:
					return "配置文件只读";

				case MailState.SaveFailure:
					return "保存不成功";

				case MailState.SmtpServerNotFind:
					return "找不到指定的SMTP服务器";

				case MailState.UserNameOrPasswordError:
					return "用户名或密码错误";

				case MailState.AttachmentSizeLimit:
					return "附件容量受到限制";

				case MailState.MustIssueStartTlsFirst:
					return "SMTP 服务器要求安全连接(SSL)或客户端未通过身份验证。";

				case MailState.NonsupportSsl:
					return "服务器不支持安全连接";

				case MailState.PortError:
					return "不能建立连接，或者SMTP端口设置有错误";

				case MailState.Ok:
					return "邮件发送成功";
			}
			return "未知的错误";
		}

		/// <summary>
		/// 发送邮件并返回状态信息
		/// </summary>
		/// <returns>状态信息</returns>
		public MailState Send()
		{
			MailConfig mailConfig = ConfigHelper.Get<MailConfig>();
			MailState mailcode = ValidMail(mailConfig);
			if (mailcode == MailState.None)
			{
				MimeMessage mailMessage = GetMailMessage(mailConfig);
				try
				{
					using (var client = new SmtpClient())
					{
						//连接到Smtp服务器
						client.Connect(mailConfig.MailServer, mailConfig.Port, mailConfig.EnabledSsl);
						//登陆
						client.Authenticate(mailConfig.MailServerUserName, mailConfig.MailServerPassWord);
						//发送
						client.Send(mailMessage);
						//断开
						client.Disconnect(true);
					}
					mailcode = MailState.Ok;
				}
				catch (SmtpCommandException exception)
				{
					switch (exception.StatusCode)
					{
						case SmtpStatusCode.MailboxNameNotAllowed:
							mailcode = MailState.UserNameOrPasswordError;
							break;
						default:
							mailcode = MailState.SendFailure;
							break;
					}
					if (exception.InnerException is IOException)
					{
						mailcode = MailState.AttachmentSizeLimit;
					}
					else if (exception.InnerException is WebException)
					{
						if (exception.InnerException.InnerException == null)
						{
							mailcode = MailState.SmtpServerNotFind;
						}
						else if (exception.InnerException.InnerException is SocketException)
						{
							mailcode = MailState.PortError;
						}
					}
					else
					{
						mailcode = MailState.NonsupportSsl;
					}
				}
			}
			this.Msg = GetMailStateInfo(mailcode);
			return mailcode;
		}

		/// <summary>
		/// 得到电子邮件对象
		/// </summary>
		/// <param name="mailSettings">邮件配置文件类</param>
		/// <returns>MailMessage对象</returns>
		private MimeMessage GetMailMessage(MailConfig mailSettings)
		{
			MimeMessage message = new MimeMessage();
			//收件人地址
			foreach (MailboxAddress address in this.MailToAddressList)
			{
				message.To.Add(address);
			}
			//抄送人地址
			if (this.MailCopyToAddressList != null)
			{
				foreach (MailboxAddress address2 in this.MailCopyToAddressList)
				{
					message.Cc.Add(address2);
				}
			}
			//回复地址
			if (this.ReplyTo != null)
			{
				message.ReplyTo.Add(this.ReplyTo);
			}
			//发件人地址
			if (!string.IsNullOrEmpty(this.FromName))
			{
				message.From.Add(new MailboxAddress(FromName, mailSettings.MailFrom));
			}
			else
			{
				message.From.Add(new MailboxAddress(mailSettings.MailFrom));
			}
			message.Priority = this.Priority;
			message.Subject = this.Subject;
			//添加正文内容
			TextPart body;
			if (IsBodyHtml)
			{
				body = new TextPart(TextFormat.Html);
			}
			else
			{
				body = new TextPart(TextFormat.Plain);
			}
			body.SetText(Encoding.UTF8, MailBody);
			var multipart = new Multipart("mixed");
			multipart.Add(body);
			//添加附件
			if (!string.IsNullOrWhiteSpace(AttachmentFilePath))
			{
				//生产一个绝对路径
				var absolutePath = FileHelper.MapPath(AttachmentFilePath);
				//附件
				var attachment = new MimePart()
				{
					//读取文件(只能用绝对路径)
					Content = new MimeContent(File.OpenRead(absolutePath), ContentEncoding.Default),
					//ContentObject = new ContentObject(File.OpenRead(absolutePath), ContentEncoding.Default),
					ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
					ContentTransferEncoding = ContentEncoding.Base64,
					//文件名字
					FileName = Path.GetFileName(absolutePath)
				};
				//添加附件
				multipart.Add(attachment);
			}
			message.Body = multipart;

			return message;
		}
		/// <summary>
		/// 验证邮件配置信息并返回邮件状态信息
		/// </summary>
		/// <param name="mailSettings">邮件配置文件对象</param>
		/// <returns>邮件状态信息</returns>
		private MailState ValidMail(MailConfig mailSettings)
		{
			MailState none = MailState.None;
			if (string.IsNullOrEmpty(mailSettings.MailFrom) || string.IsNullOrEmpty(mailSettings.MailServer))
			{
				return MailState.MailConfigIsNullOrEmpty;
			}
			if (this.MailToAddressList == null)
			{
				return MailState.NoMailToAddress;
			}
			if (string.IsNullOrEmpty(this.Subject))
			{
				return MailState.NoSubject;
			}
			if (!string.IsNullOrEmpty(this.AttachmentFilePath) && !System.IO.File.Exists(this.AttachmentFilePath))
			{
				none = MailState.FileNotFind;
			}
			return none;
		}
	}
}
