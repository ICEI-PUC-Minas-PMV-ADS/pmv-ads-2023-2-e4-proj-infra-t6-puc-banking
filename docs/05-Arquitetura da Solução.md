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

O diagrama de classe é uma representação visual da estrutura e das relações entre as classes de um sistema orientado a objetos. Ele fornece uma visão abstrata dos objetos que compõem o sistema, bem como seus atributos e métodos.

A figura abaixo ilustra o diagrama de classes para o sistema proposto.

![pucbanking-diagrama-de-classes](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/3124c437-443f-4955-940e-c8ad1bc05143)

## Modelo ER

O modelo Entidade-Relacionamento (MER) é uma representação visual dos dados e relacionamentos das entidades do sistema. No MER, as entidades são representadas por retângulos, cada um com seu nome correspondente, e os relacionamentos são representados com losangos, com sua respectiva interação entre as entidades.

A figura abaixo ilustra o modelo de Entidade-Relacionamento para o sistema proposto.

![Diagrama em branco](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/06528e8e-c0a8-407b-b4c1-8c586ff49fda)

## Esquema Relacional

O Esquema Relacional é uma ferramenta gráfica usada para modelar e representar a estrutura lógica de um banco de dados. Ele é amplamente utilizado na fase de projeto de sistemas de banco de dados, permitindo visualizar as entidades (objetos) envolvidas no sistema e as relações entre elas.

A figura abaixo ilustra o esquema relacional para o sistema proposto.

![Diagrama ER de banco de dados (pé de galinha)](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/3fdb8773-2900-4bb8-88c1-818dcaf67863)

## Modelo Físico

O Modelo Físico contém o código necessário para gerar o banco de dados da aplicação, com todas as entidades como tabelas, e seus atributos como linhas dessas tabelas. O Modelo Físico trabalha em conjunto com o Esquema Relacional, veja: Esquema relacional.

O script de criação do banco foi gerado usando o Esquema Relacional apartir da ferramenta [Lucidchart](https://www.lucidchart.com), ele se destina ao banco de dados relacional SQL Server e é gerado com a seguinte estrutura:

```sql
...

CREATE TABLE "User" (
  "email" nvarchar(50),
  "password" nvarchar(50),
  "name" nvarchar(50)
  PRIMARY KEY ("email")
);

...
```

O modelo completo pode ser encontrado em:  
- - **`pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/src/db/pucbanking.sql`**  

ou acessando o Link: [**Pucbanking.sql**]().

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
