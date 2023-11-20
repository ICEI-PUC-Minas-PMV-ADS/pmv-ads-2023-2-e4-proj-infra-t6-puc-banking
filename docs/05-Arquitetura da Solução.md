# Arquitetura da Solução

A arquitetura de um projeto de software é o alicerce estrutural que define a organização e interconexão de seus componentes, visando atender aos requisitos funcionais e não funcionais de forma eficiente e sustentável. É um plano mestre que orienta o desenvolvimento, facilitando a compreensão, a manutenção e a evolução do sistema ao longo do tempo. A arquitetura distribuída é o modelo descentralizado que permite que diferentes partes do sistema operem em conjunto, proporcionando eficiência, escalabilidade e tolerância a falhas. Componentes interconectados colaboram harmoniosamente, abrindo portas para uma experiência de usuário fluida e confiável. Abaixo está a arquitetura para o sistema proposto:

![diagrama-arquitetura-puc-banking](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/dbdd3adc-4ed2-4ce8-a7a1-84654fcdd59c)

A arquitetura do sistema está baseada em microserviços, onde cada serviço tem sua responsabilidade e seus recursos próprios. Abaixo está de forma mais detalhada cada componente dessa arquitetura e como eles se relacionam entre si.

### Identity service

É o serviço responsável por controlar todos os dados de acesso do usuário, além de fornecer endpoints para cadastro de novos usuários e login.  

As dependências desse serviço são:

- Banco de dados **SQL Server**
- Barramento de eventos

### Account service

É o serviço responsável por controlar todos os dados bancários do usuário, como histórico de pagamentos, limite do cartão, etc. O Serviço fornece endpoints para verificar histórico de pagamentos, os limites do cartão e dados da conta.

As depêndencias desse serviço são:

- Banco de dados **SQL Server**
- Barramento de eventos

### Card service

É o serviço responsável por criar, validar e gerenciar os cartões.

As depêndencias desse serviço são:

- Banco de dados **SQL Server**
- Barramento de eventos

### Payment service

É o serviço responsável por efetuar pagamentos.

As depêndencias desse serviço são:

- Banco de dados **SQL Server**
- Barramento de eventos

## Diagrama de Classes

O diagrama de classes ilustra graficamente como será a estrutura do software, e como cada uma das classes da sua estrutura estarão interligadas. Essas classes servem de modelo para materializar os objetos que executarão na memória.

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Classes”.

> - [Diagramas de Classes - Documentação da IBM](https://www.ibm.com/docs/pt-br/rational-soft-arch/9.6.1?topic=diagrams-class)
> - [O que é um diagrama de classe UML? | Lucidchart](https://www.lucidchart.com/pages/pt/o-que-e-diagrama-de-classe-uml)

## Modelo ER

O Modelo ER representa através de um diagrama como as entidades (coisas, objetos) se relacionam entre si na aplicação interativa.]

As referências abaixo irão auxiliá-lo na geração do artefato “Modelo ER”.

> - [Como fazer um diagrama entidade relacionamento | Lucidchart](https://www.lucidchart.com/pages/pt/como-fazer-um-diagrama-entidade-relacionamento)

## Esquema Relacional

O Esquema Relacional corresponde à representação dos dados em tabelas juntamente com as restrições de integridade e chave primária.
 
As referências abaixo irão auxiliá-lo na geração do artefato “Esquema Relacional”.

> - [Criando um modelo relacional - Documentação da IBM](https://www.ibm.com/docs/pt-br/cognos-analytics/10.2.2?topic=designer-creating-relational-model)

## Modelo Físico

Entregar um arquivo banco.sql contendo os scripts de criação das tabelas do banco de dados. Este arquivo deverá ser incluído dentro da pasta src\bd.

## Tecnologias Utilizadas

Descreva aqui qual(is) tecnologias você vai usar para resolver o seu problema, ou seja, implementar a sua solução. Liste todas as tecnologias envolvidas, linguagens a serem utilizadas, serviços web, frameworks, bibliotecas, IDEs de desenvolvimento, e ferramentas.

Apresente também uma figura explicando como as tecnologias estão relacionadas ou como uma interação do usuário com o sistema vai ser conduzida, por onde ela passa até retornar uma resposta ao usuário.

## Hospedagem

Explique como a hospedagem e o lançamento da plataforma foi feita.

> **Links Úteis**:
>
> - [Website com GitHub Pages](https://pages.github.com/)
> - [Programação colaborativa com Repl.it](https://repl.it/)
> - [Getting Started with Heroku](https://devcenter.heroku.com/start)
> - [Publicando Seu Site No Heroku](http://pythonclub.com.br/publicando-seu-hello-world-no-heroku.html)

## Qualidade de Software

Conceituar qualidade de fato é uma tarefa complexa, mas ela pode ser vista como um método gerencial que através de procedimentos disseminados por toda a organização, busca garantir um produto final que satisfaça às expectativas dos stakeholders.

No contexto de desenvolvimento de software, qualidade pode ser entendida como um conjunto de características a serem satisfeitas, de modo que o produto de software atenda às necessidades de seus usuários. Entretanto, tal nível de satisfação nem sempre é alcançado de forma espontânea, devendo ser continuamente construído. Assim, a qualidade do produto depende fortemente do seu respectivo processo de desenvolvimento.

A norma internacional ISO/IEC 25010, que é uma atualização da ISO/IEC 9126, define oito características e 30 subcaracterísticas de qualidade para produtos de software.
Com base nessas características e nas respectivas sub-características, identifique as sub-características que sua equipe utilizará como base para nortear o desenvolvimento do projeto de software considerando-se alguns aspectos simples de qualidade. Justifique as subcaracterísticas escolhidas pelo time e elenque as métricas que permitirão a equipe avaliar os objetos de interesse.

> **Links Úteis**:
>
> - [ISO/IEC 25010:2011 - Systems and software engineering — Systems and software Quality Requirements and Evaluation (SQuaRE) — System and software quality models](https://www.iso.org/standard/35733.html/)
> - [Análise sobre a ISO 9126 – NBR 13596](https://www.tiespecialistas.com.br/analise-sobre-iso-9126-nbr-13596/)
> - [Qualidade de Software - Engenharia de Software 29](https://www.devmedia.com.br/qualidade-de-software-engenharia-de-software-29/18209/)
