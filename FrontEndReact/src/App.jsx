import { useState } from 'react'
import { Grid,  Button, Tab,  CircularProgress } from '@mui/material'
import { TabPanel, TabList, TabContext } from '@mui/lab'
import TabelaDestinos from './components/TabelaDestinos';
import axios from 'axios'

import './App.css'

function App() {

  const [abaAtual, setAbaAtual ] = useState('get-all-destinos');
  const [ linhas, setLinhas ] = useState([]);

  const mudarDeAba = (evento, value) => {
    setAbaAtual(value)
  }

  const requisicao = async (metodo, parametros, caminho) => {
     const { data } = await axios({
      method: 'get', 
      url: `https://localhost:7079${caminho}`, 
      data: parametros,
      headers: { 
        'Access-Control-Allow-Origin': '*',
        crossDomain: true,
      },
    })
    return data;
  }

  const colunas = [
    { field: 'Id', headerName: 'ID', width: 30 },
    { field: 'Nome', headerName: 'NOME', width: 130 },
    { field: 'Cidade', headerName: 'CIDADE', width: 200 },
    { field: 'Estado', headerName: 'ESTADO', width: 100 },
    { field: 'PrecoDoPacote', headerName: 'PREÇO DO PACOTE', width: 110 },
    { field: 'Promocao', headerName: 'É PROMOÇÃO?', width: 130 },
    { field: 'Desconto', headerName: 'DESCONTO', width: 130 },
    { field: 'UrlDaImagem', headerName: 'URL DA IMAGEM', width: 130 },
]

  const endpoints = [
    {
      title: 'Listar todos os Destinos',
      method: 'GET',
      params: [],
      returnType: "Retorna uma lista de objetos de Destinos e seus campos",
      path: '/api/Destino',
      value: 'get-all-destinos',
      Component: <div>
          <h2>Lista de Destinos</h2>
          <TabelaDestinos 
            linhas={linhas} 
            colunas={colunas} 
            requisicao={requisicao} 
            setLinhas={setLinhas}
          />
        </div>
    },
   ]

  const selectedEndpoint = endpoints.findIndex(({ value }) => abaAtual === value);

     return (
    <div className="App">
      <Grid sx={{ width: 1000 }}>
        <TabContext value={abaAtual}>
          <TabList onChange={mudarDeAba}>
            {endpoints.map((endpoint, index) =>(
                !endpoint.hidden && <Tab 
                  key={index}
                  style={{ outline: 'none'}} 
                  label={endpoint.title}
                  value={endpoint.value}
                >
              </Tab>
              ))}
          
          </TabList>
          {endpoints[selectedEndpoint].Component}
        </TabContext>
      </Grid>
    </div>
  )
}

export default App
