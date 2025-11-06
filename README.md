# 🏨 Sistema de Gerenciamento de Hospedagem em C#
Este projeto é uma aplicação de console desenvolvida em C# que simula um sistema básico de gerenciamento de reservas em uma hospedaria. Ele foi construído com foco em __Programação Orientada a Objetos (POO)__ para demonstrar o uso de classes, encapsulamento, regras de negócio e a interação guiada pelo console.
### ⚙️ Tecnologias Utilizadas
* __Linguagem__: C#
* __Framework__: .NET (Console Application)
* __Recursos__: LINQ (System.Linq), System.Collections.Generic (Listas)
### ✨ Funcionalidades
O sistema oferece um menu interativo com as seguintes operações:
1. __Criar Nova Reserva__: Guia o usuário pela seleção de hóspedes, suíte e dias de reserva.
2. __Listar Reservas Ativas__: Exibe os detalhes de todas as reservas já efetuadas.
3. __Regras de Negócio e Descontos__: Aplica lógica de validação e cálculo de preços.
### 📐 Regras de Negócio Implementadas
O projeto inclui regras essenciais para a gestão de hospedagem:
1. __Capacidade da Suíte__
A reserva só é permitida se o número de hóspedes for __menor ou igual__ à capacidade máxima da suíte selecionada.
Caso a capacidade seja excedida, o sistema impede o cadastro e lança uma exceção.
2. __Cálculo de Diárias e Descontos__
O valor base é calculado multiplicando os __Dias Reservados__ pelo __Valor da Diária__ da suíte.
É concedido um desconto de 10% no valor total se a reserva for de __10 dias ou mais__.
3. __Gerenciamento de Dados__
As informações de __suítes disponíveis__ são carregadas na inicialização do sistema.
### 📂 Estrutura de Classes (POO)
O projeto é modularizado em quatro classes principais, cada uma com sua responsabilidade bem definida (Princípio da Responsabilidade Única - SRP):
1. __Classe Pessoa__ (_Pessoa.cs_): Representa um indivíduo (hóspede, contato).
2. __Classe Suite__ (_Suite.cs_): Define as características físicas de uma suíte (ID, Tipo, Capacidade e Valor da Diária).
3. __Classe Reserva__ (_Reserva.cs_): Contém toda a lógica da reserva: lista de hóspedes, suíte, dias, validação de capacidade e cálculo de valor.
4. __Classe MenuHospedaria__ (_MenuHospedaria.cs_): Gerencia o fluxo da aplicação (menu, entrada/saída de dados) e orquestra a criação de objetos _Reserva_ e a seleção de _Suite_.
### 🚀 Como Executar
Para testar o Sistema de Gerenciamento de Hospedagem em sua máquina:
1. __Pré-requisitos__: Certifique-se de ter o __.NET SDK__ instalado (versão 6.0 ou superior, recomendada para C# moderno).
2. __Clonar o Repositório__:
```Bash
git clone https://github.com/GilianoGN/DesafioProjetoHospedagem.git
cd DesafioProjetoHospedagem
```
3. __Executar o Projeto__:Utilize o comando _dotnet run_ no terminal, dentro da pasta do projeto.
```Bash
dotnet run
```
4. __Interação__: Siga as instruções do menu de console para cadastrar hóspedes e fazer uma nova reserva.