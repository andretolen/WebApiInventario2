using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Web;
using WebApiInventario.Models;

namespace WebApiInventario.Helper
{
    public class MessengerService
    {
        const string MSG_QUEUE = @".\private$\InventarioQueue";

        MessageQueue _msgQueue = null;

        public MessengerService()
        { 
            
        }

        public void SendMessage(int id)
        {
            try
            {                

                if (MessageQueue.Exists(MSG_QUEUE))
                {
                    _msgQueue = new MessageQueue(MSG_QUEUE);
                }
                else
                {
                    MessageQueue.Create(MSG_QUEUE);
                }

                string _msgText = String.Format("Elemento eliminado {0} del inventario con fecha {1}", id, DateTime.Now.ToString());

                var elemento = _msgQueue.GetAllMessages().Where(x => x.Label == id.ToString()).FirstOrDefault();

                if (elemento == null)
                {
                    Message _msg = new Message();
                    _msg.Body = _msgText;
                    _msg.Label = id.ToString(); 
                    _msgQueue.Send(_msg);
                }
            }
            catch
            {
                throw;
            }
        }             

        public List<MSMQMessage> ItemsExpired()
        {
            List<MSMQMessage> _msgList = new List<MSMQMessage>();

            if (MessageQueue.Exists(MSG_QUEUE))
            {
                _msgQueue = new MessageQueue(MSG_QUEUE);
            }
            else
            {
                throw new Exception("Message Queue does not exist");
            }          
            
            foreach (Message _message in _msgQueue.GetAllMessages())
            {
                MSMQMessage _msmqmessage = new MSMQMessage();                

                _msmqmessage.Label = _message.Label;
                _message.Formatter = new XmlMessageFormatter(new String[] { "System.String,mscorlib" });
                _msmqmessage.Body = _message.Body.ToString();
                _msgList.Add(_msmqmessage);
            }

            return _msgList;

        }

        public void ExpireElement(List<Inventario> listaInventario)
        {
            var lista = listaInventario.Where(x => x.FechaCaducidad < DateTime.Today).ToList();

            foreach (Inventario invent in lista)
            {
                try
                {            

                    if (MessageQueue.Exists(MSG_QUEUE))
                    {
                        _msgQueue = new MessageQueue(MSG_QUEUE);
                    }
                    else
                    {
                        MessageQueue.Create(MSG_QUEUE);
                    }

                    string _msgText = String.Format("Elemento caducado: {0} con identificador {1} del inventario con fecha de caducidad {2}", invent.CodigoProducto, invent.IdInventario, invent.FechaCaducidad.ToString("dd/MM/yyyy"));

                    Message _msg = new Message();

                    var mensaje = _msgQueue.GetAllMessages().Where(x => x.Label.Equals(invent.IdInventario.ToString())).FirstOrDefault();

                    if (mensaje == null)
                    {
                        _msg.Body = _msgText;
                        _msg.Label = invent.IdInventario.ToString();  //new Guid().ToString();
                        _msgQueue.Send(_msg);
                    }                 
                    
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}