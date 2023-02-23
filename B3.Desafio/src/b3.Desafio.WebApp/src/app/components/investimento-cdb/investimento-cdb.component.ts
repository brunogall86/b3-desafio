import { InvestimentoCdbService } from './investimento.service';
import { Component } from '@angular/core';
import { InvestimentoRequest, InvestimentoResponse, RendimentoResponse } from './investimento.model';
import { Router } from '@angular/router';


@Component({
  selector: 'app-investimento-cdb',
  templateUrl: './investimento-cdb.component.html',
  styleUrls: ['./investimento-cdb.component.css']
})
export class InvestimentoCdbComponent {

  hasData:boolean = false;
  dado: InvestimentoResponse = { rendimentos : []};
  displayedColumns = ['mesCalculado','valorInicialnvestido','valorFinalCalculado'];

  investimentoRequest: InvestimentoRequest = {};

  
  constructor(private service: InvestimentoCdbService,
              private router: Router) {}

  simular() : void {
    //let request: InvestimentoRequest = { prazo : 10, valorInicial : 1200 };

    this.service.simular(this.investimentoRequest).subscribe((retorno) => {
       if(!retorno.isErrors)
        this.carregarGrid(retorno.dados as InvestimentoResponse)
    });
  } 

  limpar() : void {
    this.hasData = false;
    this.dado = { rendimentos : []};
    this.investimentoRequest = {};
  }

  carregarGrid(dados: InvestimentoResponse)
  {
    this.dado = dados;
    this.hasData = true;
  }
}
