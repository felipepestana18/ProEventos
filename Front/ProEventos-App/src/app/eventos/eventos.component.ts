import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltados: any = [];
  larguraImg: number = 50;
  alturaImg: number = 50;
  mostrarImagem: Boolean = true;
  private _filtroLista: string = '';

  public get filtrolista(): string {
    return this._filtroLista;
  }

  public set filtrolista(value: string) {
    this._filtroLista = value;
    this.eventosFiltados = this.filtrolista ? this.filtrarEventos(this.filtrolista) : this.eventos
  }

  filtrarEventos(filtrarPor: string): any {

    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos();
  }


  alterarImagem (): void {
    this.mostrarImagem = !this.mostrarImagem;
  }
  public getEventos(): void {
    this.http.get("https://localhost:5001/api/eventos").subscribe(

      response => {
        this.eventos = response;
        this.eventosFiltados = response;
      },

      error => console.log(error),
    );


    // this.eventos = [
    //   {
    //   Tema: 'Angular',
    //   Local: "SP"
    //   },
    //   {
    //     Tema: 'NET 5',
    //     Local: "Rio Preto"
    //   },
    //   {
    //     Tema: 'Angular Suas Novidades',
    //     Local: "Campinas"
    //     }
    // ]
  }

}
