import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public envetos: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos();
  }

  public getEventos(): void {
    this.http.get("https://localhost:5001/api/eventos").subscribe(
      response => this.envetos = response,
      error => console.log(error),
    );
    this.envetos = [
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
  }

}
