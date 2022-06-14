﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.InnerUtil;
using BL.InnerException;
using BL.Infra;

namespace BL.InnerUtil
{
    public class MakeLog
    {

        private static ConfigureService _configuration = new ConfigureService();

        /// <summary>
        /// Cria uma mensagem, utilizando as mensagens das exceptions lançadas, gera um código para identificar a mensage.
        /// Salva a mensagem com o código no arquivo de log de suporte
        /// </summary>
        /// <param name="ex">Exception lançada</param>
        /// <param name="messageError">Mensagem específica</param>
        /// <param name="detailProcess">Detalhe da localização que tratou a exceção</param>
        /// <returns>Retorna o código que foi gerado para essa mensagem de erro</returns>
        public static int BuildErrorLogSupport(Exception ex, string messageError, string detailProcess)
        {
            int codeError = CodeRandom();
            string errorCode = MessagesOfReturn.CodeErrorInfo(codeError);
            string infoDate = MessagesOfReturn.ActualDateInfo;
            string textForLog = "";

            textForLog += MessagesOfReturn.LineDashed;
            textForLog += errorCode;
            textForLog += $"{detailProcess} - {infoDate}";
            textForLog += messageError;
            textForLog += BuildMessageForSupportLog(ex);
            textForLog += MessagesOfReturn.LineDashed;

            SaveLog(_configuration.RootLog, Option.NameFileLogSuport, textForLog);
                        
            return codeError;
        }

        /// <summary>
        /// Constrói o arquivo de log, se já existir apenas alimenta
        /// </summary>
        /// <param name="messageLog">string com a mensagem que será gravada no log</param>
        /// <param name="numberOfMessage">QUal mensagem se refere</param>
        public static void BuildLogUser(string messageLog, NumberOfMessage numberOfMessage, TimeSpan totalTime)
        {
            string textForLog = "";

            textForLog += MessagesOfReturn.LineDashed;
            textForLog += MessagesOfReturn.TitleLogUser(numberOfMessage);
            textForLog += MessagesOfReturn.ActualDateInfo;
            textForLog += MessagesOfReturn.TotalTime(totalTime);
            textForLog += messageLog;
            textForLog += MessagesOfReturn.LineDashed;

            SaveLog(_configuration.RootLog, Option.NameFileLogUser, textForLog);
        }

        private static int CodeRandom()
        {
            Random ran = new Random(DateTime.Now.Millisecond);
            return ran.Next();
        }
        
        private static void SaveLog(string filePath, string fileName, string text)
        {
            try
            {
                RecordFile.CreateDirectorIfNotExisty(filePath);
                string file = $"{filePath}{fileName}";
                RecordFile.SaveFile(file, text);
            }
            catch (Exception)
            {
                string textException = MessagesOfReturn.ErrorAccessPath(fileName, filePath);
                RecordFile.SaveFile(Option.PathFileLogError, textException);
            }
        }

        private static string BuildMessageForSupportLog(Exception ex)
        {
            string msgException = "";
            string stackTracer = "";
            Exception exception = ex;
            while (exception != null)
            {
                if (!string.IsNullOrEmpty(exception.Message))
                {
                    msgException += $"{exception.Message}{Environment.NewLine}";
                    stackTracer += $"{exception.StackTrace}{Environment.NewLine}{Environment.NewLine}";
                }

                exception = exception.InnerException;
            }
            msgException += $"{Environment.NewLine}Stack Trace:{Environment.NewLine}{stackTracer}";
            return msgException;
        }
    }
}
