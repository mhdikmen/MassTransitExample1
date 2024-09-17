# MassTransit Example

This project demonstrates how to use **MassTransit**, a .NET-based message bus abstraction, with RabbitMQ for building message-based applications.

## Overview

MassTransit simplifies working with message brokers such as RabbitMQ, Azure Service Bus, and others. It supports:

- Message-based communication
- Distributed transactions and sagas
- Built-in retry and fault handling

This example shows how to consume messages and handle faults via RabbitMQ.

## Setup

1. **Install Required Packages:**
   - MassTransit.AspNetCore for Common
   - MassTransit.RabbitMQ for Common
   - Microsoft.Extensions.Hosting for Consumer and Producer

2. **Docker Setup**:
   Make sure Docker Desktop is installed. Then, run the RabbitMQ container:
   ```bash
   docker run -d --name messagebroker -p 15672:15672 -p 5672:5672 rabbitmq:3-management




[See LinkeIn Article](https://www.linkedin.com/pulse/what-masstransit-muhammed-hanifi-dikmen-7ranf/?trackingId=q%2BcJX5BORFW%2FJo%2FZq4gtVw%3D%3D)