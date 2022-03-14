import { clear } from "@testing-library/user-event/dist/clear";
import { Component, useState } from "react";
import ConsultaFipe from "./components/ConsultaFipe";
import './global.css';

import brasilapi from "./services/brasilapi";
import { Axios } from "axios";

export default function App() {

    const [codigoFipe, setCodigoFipe] = useState('');
    const [ano, setAno] = useState('');
    const [fipe, setFipe] = useState([]);
    const [placa, setPlaca] = useState('');
    const [mensagemErro, setMensagemErro] = useState('');
    const [mensagemSucesso, setMensagemSucesso] = useState('');

    async function PesquisaFipe(event) {
        event.preventDefault();
        setFipe([]);
        setMensagemErro('');
        setMensagemSucesso('');

        const data = {
            codigoFipe, ano
        };

        try {
            const response = await
                brasilapi.post('Fipe/ConsultaFipe', data)
                    .then(response => { setFipe(response.data) });
            
        }
        catch (error) {
            setMensagemErro('Código Fipe não encontrado')
        }
    }

    async function AdicionaVeiculo(event) {
        event.preventDefault();
        setMensagemErro('');

        const veiculo = {
            codigoFipe, ano, placa
        };

        if (placa != ''){
            if (fipe.codigoFipe != undefined) {
                setMensagemErro('');
    
                try {
                    const response = await
                        brasilapi.post('Fipe/AdicionaVeiculo', veiculo);
                    
                    setMensagemSucesso('Veículo adicionado com sucesso');
                }
                catch (error) {
                    setMensagemErro('Houve um erro ao adicionar o veículo')
                }
    
                
            }
            else {
                setMensagemSucesso('');
                setMensagemErro("Nâo é possível adicionar um veículo sem um código fipe válido");
            }
        }
        else {
            setMensagemErro("A placa do veículo não pode ser vazia")
        }
    }

    async function ConsultaVeiculo(event) {
        event.preventDefault();
        setMensagemErro('');

        if (placa != '')
        {
            try {
                const response = await
                    brasilapi.get('Fipe/' + placa)
                    .then(response => { setFipe(response.data) });
            }
            catch (error) {
                setMensagemErro('Houve um erro ao tentar encontrar o veículo');
            }
        }
        else{
            setFipe([]);
        setMensagemErro('');
        setMensagemSucesso('');
        }
    }

    return (
        <div>
            <label id="erro">{mensagemErro}</label>
            <label id="sucesso">{mensagemSucesso}</label>
            <div className="consulta-container">

                <section className="consulta form">
                    <form onSubmit={PesquisaFipe}>
                        <h1>Consulta dados da tabela Fipe</h1>
                        <input placeholder="Código Fipe"
                            value={codigoFipe}
                            onChange={e => setCodigoFipe(e.target.value)} />
                        <input placeholder="Ano"
                            value={ano}
                            onChange={e => setAno(e.target.value)} />
                        <button className="button" type="submit">Consultar</button>
                    </form>

                </section>

                <section className="consulta dados">
                    <h1>Dados do fipe consultado: </h1>
                    <ul>
                        <li><strong>Valor: </strong> {fipe.valor}</li>
                        <li><strong>Marca: </strong>{fipe.marca}</li>
                        <li><strong>Modelo: </strong>{fipe.modelo}</li>
                        <li><strong>Ano: </strong>{fipe.ano}</li>
                        <li><strong>Combustível: </strong>{fipe.combustivel}</li>
                        <li><strong>Código Fipe: </strong>{fipe.codigoFipe}</li>
                        <li><strong>Mês de Referência: </strong>{fipe.mesReferencia}</li>
                        <li><strong>Tipo de Veículo: </strong>{fipe.tipoVeiculo}</li>
                        <li><strong>Sigla do combustivel: </strong>{fipe.siglaCombustivel}</li>
                        <li><strong>Data da Consulta: </strong>{fipe.dataConsulta}</li>
                    </ul>
                </section>

                <section className="form-veiculo">
                    <input placeholder="Placa do Veículo"
                        onChange={e => setPlaca(e.target.value)}>
                    </input>
                    <div className="add-veiculo">

                        <form onSubmit={AdicionaVeiculo}>

                            <button className="button" type="submit">Adicionar Veículo</button>
                        </form>
                    </div>

                    <div className="consulta-veiculo">
                        <form onSubmit={ConsultaVeiculo}>

                            <button className="button" type="submit">Consultar dados do Veículo</button>
                        </form>
                    </div>

                </section>
            </div>
        </div>

    );

}
