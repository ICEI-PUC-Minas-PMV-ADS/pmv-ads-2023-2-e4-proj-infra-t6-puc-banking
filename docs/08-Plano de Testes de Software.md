# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

Apresente os cenários de testes utilizados na realização dos testes da sua aplicação. Escolha cenários de testes que demonstrem os requisitos sendo satisfeitos.

Segue abaixo os testes funcionais a serem realizados no aplicativo: 

<table>
  <tr>
    <td align="center" width="100">Caso de Teste</td>
    <td align="center" width="800">CT-01 - Acesso a página "Home e Cadastro</td>
  </tr>
  <tr>
    <td align="center">Requisito Associado</td>
    <td align="center">RF-001 Permitir que o usuário crie uma conta na plataforma</td>
  </tr>
   <tr>
    <td align="center">Objetivo do Teste</td>
    <td align="center">Utilizar a funcionalidade de "cadastro" e acessar a página "home"</td>
  </tr>
  <tr>
    <td align="center">Passos</td>
    <td align="center">Acessar o Sistema, Automaticamente entrar na página de cadastro, Cadastrar conforme seus dados, Clicar em "CADASTRAR"</td>
  </tr>
  <tr>
    <td align="center">Critério de Êxito</td>
    <td align="center">- Cadastro realizado com sucesso, o login deve ser fetio automaticamente e o usuário deve ser redirecionado para a página "HOME"</td>
  </tr>
</table>

<table>
  <tr>
    <td align="center" width="100">Caso de Teste</td>
    <td align="center" width="800">CT-02 - Efetuar Login</td>
  </tr>
  <tr>
    <td align="center">Requisito Associado</td>
    <td align="center">RF-001 Permitir que o usuário crie uma conta na plataforma</td>
  </tr>
   <tr>
    <td align="center">Objetivo do Teste</td>
    <td align="center">Verificar se o usuário é capaz de realizar login</td>
  </tr>
  <tr>
    <td align="center">Passos</td>
    <td align="center">Acessar o Sistema, Clicar no botão de login, Preencher o campo usuário, Preencher o campo senha, Apertar o botão de login</td>
  </tr>
  <tr>
    <td align="center">Critério de Êxito</td>
    <td align="center">- Login realizado com sucesso e o usuário deve ser redirecionado para a página "HOME"</td>
  </tr>
</table>

<table>
  <tr>
    <td align="center" width="100">Caso de Teste</td>
    <td align="center" width="800">CT-03 - Visualizar o saldo do cartão</td>
  </tr>
  <tr>
    <td align="center">Requisito Associado</td>
    <td align="center">RF-006 O Usuário deve poder visualizar sua conta com todas as suas principais informações financeiras.</td>
  </tr>
   <tr>
    <td align="center">Objetivo do Teste</td>
    <td align="center">Verificar se o usuário é capaz de visualizar suas principais informações financeiras</td>
  </tr>
  <tr>
    <td align="center">Passos</td>
    <td align="center">Fazer o login, Ser direcionado para a página "Home" e Conferir se os dados foram apresentados </td>
  </tr>
  <tr>
    <td align="center">Critério de Êxito</td>
    <td align="center">- Os dados e informações financeiras estão na aplicação</td>
  </tr>
</table>

<table>
  <tr>
    <td align="center" width="100">Caso de Teste</td>
    <td align="center" width="800">CT-04 - Visualizar o extrato</td>
  </tr>
  <tr>
    <td align="center">Requisito Associado</td>
    <td align="center">RF-007 O Usuário deve poder filtrar por data as transações em seu extrato.</td>
  </tr>
   <tr>
    <td align="center">Objetivo do Teste</td>
    <td align="center">Verificar se o usuário é capaz de visualizar seu extrato</td>
  </tr>
  <tr>
    <td align="center">Passos</td>
    <td align="center">Fazer o login, Ser direcionado para a página "Home" e acessar seu extrato</td>
  </tr>
  <tr>
    <td align="center">Critério de Êxito</td>
    <td align="center">- Informações do extrato estão na aplicação</td>
  </tr>
</table>


