using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionAppRabbitMQ
{
    public static class RabbitMQConsumer
    {
        private const string QUEUE_NAME = "queue-testes";

        [Function(nameof(RabbitMQConsumer))]
        public static void Run([RabbitMQTrigger(QUEUE_NAME, ConnectionStringSetting = "RabbitMQConnection")] string item,
            FunctionContext context)
        {
            var logger = context.GetLogger(nameof(RabbitMQConsumer));
            logger.LogInformation($"Fila: {QUEUE_NAME} | Mensagem recebida: {item}");
        }
    }
}