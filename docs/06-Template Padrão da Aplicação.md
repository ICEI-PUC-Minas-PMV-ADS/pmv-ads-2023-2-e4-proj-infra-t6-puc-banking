# Template Padrão da Aplicação

O template padrão da aplicação é um conjunto de componentes, estilos e padrões de design que são utilizados como base para a criação de uma aplicação. Para auxiliar na criação da aplicação será utilizado duas bibliotecas de estilos, **[Bootstrap]()** para o app web e **[NativeBase]()** para o app mobile.

### Tipografia

A tipografia é a arte e técnica de criação e seleção de fontes e tipografias para a impressão ou exibição digital de textos. É uma das áreas mais importantes do design gráfico e tem um impacto significativo na legibilidade, na aparência e na eficácia da comunicação visual.

#### Padrões de fontes

<table>
  <tr>
    <td width='100'><strong>Fonte</strong></td>
    <td width='100'><strong>Peso</strong></td>
    <td width='400'><strong>Uso</strong></td>
  </tr>
    <tr>
    <td>Roboto</td>
    <td>bold</td>
    <td>Para títulos</td>
  </tr>
  <tr>
    <td>Roboto</td>
    <td>medium</td>
    <td>Para textos descritivos</td>
  </tr>
  <tr>
    <td>Roboto</td>
    <td>regular</td>
    <td>Para campos de entrada e informativos</td>
  </tr>
</table>

#### Tamanhos de fonte

<table>
  <tr>
    <td width='100'><strong>Código</strong></td>
    <td width='100'><strong>Tamanho</strong></td>
    <td width='400'><strong>Uso</strong></td>
  </tr>
    <tr>
    <td>xs</td>
    <td>12</td>
    <td>Para textos complementares</td>
  </td>
  <tr>
    <td>sm</td>
    <td>14</td>
    <td>Para textos gerais</td>
  </td>
  <tr>
    <td>md</td>
    <td>16</td>
    <td>Para textos de botões e títulos secundários</td>
  </td>
  <tr>
    <td>xl</td>
    <td>20</td>
    <td>Para títulos principais</td>
  </td>
</table>

### Cores

As cores são uma parte fundamental do nosso mundo visual, e são usadas em praticamente todos os aspectos do design, da arte e da comunicação. Uma paleta de cores bem escolhida pode transmitir emoções, estabelecer uma identidade visual forte e criar uma experiência agradável e coesa para o usuário.

A paleta de cores foi gerada no site [Gerador de paleta de cores JSON](https://json-color-palette-generator.vercel.app/).

<table>
  <tr>
    <td colspan='3' align='center'><strong>Primary</strong></td>
    <td colspan='3' align='center'><strong>Neutral</strong></td>
  </tr>
  <tr>
    <td align='center'><strong>Preview</strong></td>
    <td align='center'><strong>Nome</strong></td>
    <td align='center'><strong>Hex</strong></td>
    <td align='center'><strong>Preview</strong></td>
    <td align='center'><strong>Nome</strong></td>
    <td align='center'><strong>Hex</strong></td>
  </tr>
  <tr>
    <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/e96f476d-19bf-4f01-a9ab-05eb2f4befb9'/></td>
    <td>primary.50</td>
    <td>#EEEFFF</td>
    <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/4c3b559b-2b58-43ea-8724-37ea637dd805'/></td>
    <td>neutral.50</td>
    <td>#F9FAFA</td>
  </tr>
    <tr>
    <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/58de0be0-8143-45cf-a404-c7aa12dec64b'/></td>
    <td>primary.100</td>
    <td>#DEDFFF</td>
    <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/5c2fdc5a-8202-4183-af4f-b5c8f8f4e17e'/></td>
    <td>neutral.100</td>
    <td>#F4F5F5</td>
  </tr>
      <tr>
    <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/52e73e6b-412c-4653-a425-26923998c11f'/></td>
    <td>primary.200</td>
    <td>#B8BCFC</td>
    <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/5e8a246c-2da3-4926-ae91-ed54c62f6d1e'/></td>
    <td>neutral.200</td>
    <td>#D1D2D4</td>
  </tr>
  <tr>
    <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/eb0abf11-b2a0-4752-80b2-575fc4f2e97c'/></td>
    <td>primary.300</td>
    <td>#969BF7</td>
    <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/eaa78bd5-5ebb-4653-9e7a-25e3a6a5bfe8'/></td>
    <td>neutral.300</td>
    <td>#AFB1B4</td>
  </tr>
  <tr>
  <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/b15d46f0-1008-4788-87a0-08b8b35669f8'/></td>
    <td>primary.400</td>
    <td>#7076F4</td>
    <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/89fd375b-323a-4a70-91e4-0512f742fb96'/></td>
    <td>neutral.400</td>
    <td>#8E9095</td>
  </tr>
   <tr>
  <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/5c49adfc-11bf-44f2-939b-8ce43b7c7729'/></td>
    <td>primary.500</td>
    <td>#6067ED</td>
    <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/8a935792-ebb8-4144-ae7d-7742ecaa667b'/></td>
    <td>neutral.500</td>
    <td>#6E7177</td>
  </tr>
   <tr>
  <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/5918c44f-7853-45e4-bb4a-0341af5cff34'/></td>
    <td>primary.600</td>
    <td>#5158E5</td>
    <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/d60d647f-74de-45d5-88b4-32b36f1be992'/></td>
    <td>neutral.600</td>
    <td>#56595D</td>
  </tr>
  <tr>
  <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/10e871a9-6544-41ce-9244-f08bad902e46'/></td>
    <td>primary.700</td>
    <td>#434BDB</td>
    <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/9afa9f5f-1323-45d7-98a2-c11138f2b2c1'/></td>
    <td>neutral.700</td>
    <td>#3F4145</td>
  </tr>
  <tr>
  <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/01f15628-38a8-4623-9294-d79ec88a2088'/></td>
    <td>primary.800</td>
    <td>#373ED0</td>
    <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/9c92838a-b46d-4ced-a2ce-77d8c6e48247'/></td>
    <td>neutral.800</td>
    <td>#2A2B2D</td>
  </tr>
    <tr>
  <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/fbccf3b8-6d45-4ffe-8c7a-65a897a98fd4'/></td>
    <td>primary.900</td>
    <td>#353BBB</td>
    <td><img src='https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/assets/82043220/f95417ec-95c3-46da-9bb4-2b85460abfc6'/></td>
    <td>neutral.900</td>
    <td>#161718</td>
  </tr>
</table>
