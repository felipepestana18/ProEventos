import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public envetos: any = [
    {
    Tema: 'Angular',
    Local: "SP"
    },
    {
      Tema: 'NET 5',
      Local: "Rio Preto"
    },
    {
      Tema: 'Angular Suas Novidades',
      Local: "Campinas"
      }
  ]
  constructor() { }

  ngOnInit() {
  }

}
