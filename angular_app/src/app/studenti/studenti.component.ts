import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-studenti',
  templateUrl: './studenti.component.html',
  styleUrls: ['./studenti.component.css']
})
export class StudentiComponent implements OnInit {

  title:string = 'angularFIT2';
  ime_prezime:string = '';
  opstina: string = '';
  studentPodaci: any;
  filter_ime_prezime: boolean;
  filter_opstina: boolean;
  odabraniStudent:any;


  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  testirajWebApi() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Student/GetAll?ime_prezime="+(this.filter_ime_prezime? this.ime_prezime:"")+"&opstina="+(this.filter_opstina? this.opstina:""), MojConfig.http_opcije()).subscribe(x=>{
      this.studentPodaci = x;
    });
  }
  Otvori(id:any){
    this.router.navigateByUrl("student-maticnaknjiga/"+id);
  }
  ngOnInit(): void {
    this.testirajWebApi();
  }

}
