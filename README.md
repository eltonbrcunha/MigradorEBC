# MigradorEBC

<h2>Apresentação  :speech_balloon:</h2> 
Aplicação criada com o intutito de facilitar a transferência de informações para os mais diversos bancos de dados, contato com o apoio de JSON e XML, onde o sistema carrega as informações
com base nas informações da instância SQL para que assim seja possível efetuar a exportaçao dos dados.

<h2>Imagens do projeto :computer:</h2> 

![alt text](https://github.com/eltonbrcunha/MigradorEBC/blob/main/imagens/001.jpg)
![alt text](https://github.com/eltonbrcunha/MigradorEBC/blob/main/imagens/002.jpg)

<h2>Instruções de Uso :blue_book:</h2>
Para se usar a aplicação é necessário ter uma instância SQL Server configurada com usuário e senha para que o sistema consiga efetuar o devido login, após conectar numa instância o sistema
irá listar todos os bancos de dados disponíveis (com excessão dos temp e master do SQL Server). 
Após selecionar o banco de dados, está disponível todas as tabelas do banco de dados selecionado, para consulta e exportação dos arquivos JSON e XML.

</br>
<strong>Observação</strong> 
Necessário ter uma conta com usuário e senha registrado no SQL Server

<h2>Sobre a Tecnologia usada</h2>
:white_check_mark: Linguagem: C# Windows Forms </br>
:white_check_mark: Banco de Dados: SQL Server </br>


<h2>Melhorias a serem feitas</h2>
:exclamation: Conectar em outros bancos de dados de origem, além do SQL Server
:exclamation: Efetuar a conexão entre um banco de origem e destino para que assim possa ser feita diretamente pela aplicação a transferência de dados
:exclamation: Poder configurar os tipos de dados de cada coluna do banco origem para o destino.


<h2> Desenvolvedor :technologist:</h2>
Elto Brito

