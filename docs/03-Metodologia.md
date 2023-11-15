
# Metodologia

A metodologia contempla as definições de ferramentas utilizadas pela equipe tanto para a manutenção dos códigos e demais artefatos quanto para a organização do time na execução das tarefas do projeto

## Relação de Ambientes de Trabalho

<table>
  <tr>
    <td width="300" align="center"><strong>Ambiente</strong></td>
    <td width="300" align="center"><strong>Plataforma</strong></td>
    <td width="400" align="center"><strong>Link de acesso</strong></td>
  </tr>
  <tr>
    <td>Repositório de código fonte</td>
    <td>GitHub</td>
    <td><a href="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking">Repositório PUC-BANKING</a></td>
  </tr>
  <tr>
    <td>Documento do Projeto</td>
    <td>GitHub</td>
    <td><a href="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/tree/main/docs">Documentação</a></td>
  </tr>
  <tr>
    <td>Gerenciamento do Projeto</td>
    <td>GitHub</td>
    <td><a href="https://github.com/orgs/ICEI-PUC-Minas-PMV-ADS/projects/738/views/1">Gerenciamento</a></td>
  <tr>
    <td>Projeto de Interface e Wireframes</td>
    <td>Figma</td>
    <td><a href="">Figma</a></td>
  </tr>
  <tr>
    <td>Comunicação e Brainstroming</td>
    <td>Microsoft Teams</td>
    <td><a href="">Microsoft Teams</a></td>
  </tr>
</table>

## Controle de Versão

Para gestão do código fonte do software, é utilizado um processo de controle de fluxo com base no Git Flow apresentado por Vincent Driessen (2010), mostrado na figura na seguir.

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/e6e6c551-fb51-49a0-9aab-16a484563702)

O projeto segue a seguinte convenção para o nome de branches:

- `Main`: Como Branch principal
- `Hotfix`: Para correção de bugs
- `Feature`: Para novas funcionalidades
- `Develop`: Para desenvolvimento
- `Release`: Para empacotar as modificações para o lançamento 

Quanto à gerência de issues, o projeto adota a seguinte convenção para
etiquetas:

- `documentation`: melhorias ou acréscimos à documentação
- `bug`: uma funcionalidade encontra-se com problemas
- `enhancement`: uma funcionalidade precisa ser melhorada
- `feature`: uma nova funcionalidade precisa ser introduzida

## Gerenciamento de Projeto

### Divisão de Papéis

A equipe utiliza metodologias ágeis, tendo escolhido o Scrum como base para definição do processo de desenvolvimento. A equipe está organizada da seguinte maneira:

<table>
  <tr>
    <td width="500" align="center" colspan="2">Scrum Master</td>
  </tr>
  <tr>
    <td colspan="2">Responsável por facilitar e promover um ambiente de trabalho eficiente e colaborativo para a equipe de desenvolvimento. </td>
  </tr>
  <tr>
    <td width="100" align="center"><strong>Integrantes</strong></td>
    <td width="900"><a href="https://github.com/RaulShinaede">Raul Oliveira</a></td>
  </tr>
</table>

<table>
  <tr>
    <td width="500" align="center" colspan="2">Product Owner</td>
  </tr>
  <tr>
    <td colspan="2">Responsável por representar os interesses dos stakeholders e definir as necessidades do produto. </td>
  </tr>
  <tr>
    <td width="100" align="center"><strong>Integrantes</strong></td>
    <td width="900"><a href="https://github.com/brunosellas">Bruno Sellas</a></td>
  </tr>
</table>

<table>
  <tr>
    <td width="500" align="center" colspan="2">Equipe de Desenvolvimento</td>
  </tr>
  <tr>
    <td colspan="2">Responsáveis por implementar as funcionalidades previstas do software.</td>
  </tr>
  <tr>
    <td width="100" align="center"><strong>Integrantes</strong></td>
    <td width="900"><a href="https://github.com/RaulShinaede">Raul Oliveira</a>, <a href="https://github.com/brunosellas">Bruno Sellas</a>, <a href="https://github.com/TulioFS">Marco Túlio</a></td>
  </tr>
</table>

<table>
  <tr>
    <td width="500" align="center" colspan="2">Equipe de Design</td>
  </tr>
  <tr>
    <td colspan="2">Responsáveis por projetar a interface e a identidade visual do sistema.</td>
  </tr>
  <tr>
    <td width="100" align="center"><strong>Integrantes</strong></td>
    <td width="900"><a href="https://github.com/RaulShinaede">Raul Oliveira</a></td>
  </tr>
</table>

### Processo

Para organização e distribuição das tarefas do projeto, a equipe está utilizandoo GitHub, estruturado com as seguintes listas:

**📋 Backlog**:  
🔹 Todas as tarefas identificadas no decorrer do projeto são incorporadas a está lista.  
 
**🔜 Sprint Backlog**:  
🔹 As tarefas que seram desenvolvidas na sprint são movidas para está lista.  
 
**🏗  In Progress**:  
🔹 As tarefas iniciadas são movidas para está lista.  
 
**✅ Done**:  
🔹 As tarefas finalizadas são movidas para está lista.  

O quadro kanban do projeto está disponível no link: [Project PUCBanking](https://github.com/orgs/ICEI-PUC-Minas-PMV-ADS/projects/738/views/1) e é apresentado, no estado atual, na figura abaixo:

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/f7f0eedd-bfdf-43ee-bbc7-824e812cc3b4)

### Ferramentas

As ferramentas empregadas no projeto são:

- **Editor de código**: [Visual Studio Code](https://code.visualstudio.com/)
- **Ferramentas de comunicação**: [Microsoft Teams](https://www.microsoft.com/pt-br/microsoft-teams/group-chat-software/)
- **Ferramentas de desenho de tela (_wireframing_)**: [Figma](https://figma.com/)
- **Ferramentas de gerenciamento do projeto**: [Github](https://github.com/)

O Visual Studio Code foi escolhido porque ele possui uma integração com o sistema de versão e seu suporte ao desenvolvimento com react. O Teams foi escolhido como ferramenta de comunicação por ser mais prática. Para criar diagramas utilizamos o Figma por melhor captar as necessidades da nossa solução. Por fim, para gerenciar o projeto foi escolhido o Github, por sua integração com o sistema de versão.
