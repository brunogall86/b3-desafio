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
  errors: object[] = [];

  
  constructor(private service: InvestimentoCdbService,
              private router: Router) {}

  simular() : void {
    this.service.simular(this.investimentoRequest).subscribe(
        (retorno) => {
          this.carregarGrid(retorno.dados as InvestimentoResponse)
        }, 
         (retorno) => {
          console.log(retorno.error.errors as object[]);
          this.showErrors(retorno.error.errors as object[]);
        });
  } 

  limpar() : void {
    this.hasData = false;
    this.dado = { rendimentos : []};
    this.investimentoRequest = {};
    this.errors = [];
  }

  carregarGrid(dados: InvestimentoResponse)
  {
    this.limpar();
    this.dado = dados;
    this.hasData = true;
  }

  showErrors(errors: any[]) : void {
    this.errors = errors;
    this.hasData = false;
  }
}
