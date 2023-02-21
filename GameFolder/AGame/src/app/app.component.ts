import { Component, OnInit, AfterViewInit,AfterContentInit, ViewChild, ElementRef } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import { IQuest } from './Interfaces/IQuest';
import{IMasterPackage} from './Interfaces/IMasterPackage';
import { Subject } from 'rxjs';
import { Observable } from 'rxjs';
import { Renderer2 } from '@angular/core';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'AGame';
  //-----------user location----------
  currentUserLatitude=49.8121157;
  currentUserLongitude=19.041796;
  //--------------logiczne------------
  DistanceFromLocationToGetQuestion:number = 1.2;
  MapZOOM:number = 14;
  //--------------api----------------
  constructor(private http:HttpClient, private renderer:Renderer2){};
  readonly APIurl:string ="http://127.0.0.1:5153";
  myNumber:number=12;
  //--------------model data---------------
  highScore:any;
  //DisplayLocationQuestionOnScreen:string = "nothing here";
  AnswerButtonsActive:boolean=false;
  ClosestLocation:IQuest|any;
  
  data:IQuest[]|any=[];
  ngOnInit(){
    this.PackData();
      navigator.geolocation.getCurrentPosition((position)=>{
        console.log(position.coords.latitude);
        console.log(position.coords.longitude);
        //this.currentUserLatitude=position.coords.latitude;
        //this.currentUserLongitude=position.coords.longitude;
      })
  }
  ngAfterContentInit(){
    
  }
  ngAfterViewInit():void{
    this.getClosestQuest();
    
  }
  PackData(){
    this.getData();   
    //this.getClosestQuest();
    this.getHighScore();

  }

  checkButtonsUnlock(){
    if(this.ClosestLocation.Range<this.DistanceFromLocationToGetQuestion){
      this.AnswerButtonsActive=true;
    }

  }
  getData(){     
    let url = this.APIurl+"/Quests";
    //console.log("getData() -pracuje");
    this.http.get(url).subscribe(data=>{
      //console.warn(data);
      this.data=data;
      
    });
  }
  getHighScore(){   
    let url = this.APIurl+"/api/HighScore";
    //console.log("getHighScore() -pracuje");
    this.http.get(url).subscribe(data=>{
      //console.warn("getHighScore warn: "+data);
      this.highScore=data;
    });
  }

  @ViewChild('buttonPanel') buttonPanel!: ElementRef<HTMLDivElement>;
  @ViewChild('GreenText') GreenText!: ElementRef<HTMLParagraphElement>;
  
  getClosestQuest(){   
    let url = this.APIurl+"/api/GetClosest?cuLon="+this.currentUserLongitude+"&cuLat="+this.currentUserLatitude;
    //console.log("getClosestQuest() -pracuje");
    this.http.get(url).subscribe(resp=>{
      
      this.ClosestLocation=resp;
      /*console.log(this.ClosestLocation[0]); //caly obiekt
      console.log(this.ClosestLocation[0].answer);
      console.log(this.ClosestLocation[0].correct);
      console.log(this.ClosestLocation[0].id);
      console.log(this.ClosestLocation[0].lon);
      console.log(this.ClosestLocation[0].isDone);
      console.log(this.ClosestLocation[0].lat); //double
      console.log(this.ClosestLocation[0].question); //string
      console.log(this.ClosestLocation[0].range); //int*/
      const div = this.renderer.createElement('div');
      const textGood = this.renderer.createText(this.ClosestLocation[0].question);
      const textBad = this.renderer.createText('Nic nie ma w tej okolicy');
      
      if(this.ClosestLocation[0].range<=2){
        this.renderer.appendChild(div,textGood);
        //this.AnswerButtonsActive=true;
        this.buttonPanel.nativeElement.style.visibility = "visible";
        //this.GreenText.nativeElement.style.visibility="visible";
        //console.log(this.ClosestLocation[0].Question);
      }else{
        this.renderer.appendChild(div,textBad);
        //this.AnswerButtonsActive=false;
        //document.getElementById("buttonPanel").style.visibility;
        this.buttonPanel.nativeElement.style.visibility = "hidden";
        //this.GreenText.nativeElement.style.visibility="hidden";
      }
      this.renderer.appendChild(this.GreenText.nativeElement, div);
    });
  }
  answerGivenEqualsTrue(id:number){
    console.log("ans true");
    console.log(id);
    //let headers = new HttpHeaders().set('Authorization', 'auth-token');
    
    //let x = this.http.get(this.APIurl+"/api/AnswerTrue?id="+id, {headers});
    this.http.get(this.APIurl+"/api/AnswerTrue?id="+id).subscribe(resp=>{
      console.log("send:");
      console.log(resp);
    });
    window.location.reload();
    
    
    //Quests?id=13&ans=true
  }
  answerGivenEqualsFalse(id:number){
    console.log("ans false");
    console.log(id);
    this.http.get(this.APIurl+"/api/AnswerFalse?id="+id).subscribe(resp=>{
      console.log("send:");
      console.log(resp);
    });
    window.location.reload();
  }
  
}
export interface IPost {
  id: number,
  answer:boolean,
}
  /*displayQuestion(){
    console.log("displayQuestion() pracuje");
    console.warn("range on this boi+ "+ this.ClosestLocation.Range);
    console.warn("id on this boi+ "+ this.ClosestLocation.Id);
    
    /*if(this.ClosestLocation.Range<=this.DistanceFromLocationToGetQuestion){
      this.DisplayLocationQuestionOnScreen = this.ClosestLocation.Question;
      this.AnswerButtonsActive=true;
    } else {
      this.DisplayLocationQuestionOnScreen = "W okolicy nie ma nic ciekawego";
      this.AnswerButtonsActive=false;   
    }*/
  
  /*
  //----------testowanie mastera--------------
  posts:any;
  testcopyfromjson:IQuest|any;
  
  GetJsonapi(): Observable<IQuest>{
    let headers = new HttpHeaders().set('Authorization', 'auth-token');
    return this.http.get<IQuest>("http://127.0.0.1:5153/api/GetClosest?cuLon="+this.currentUserLongitude+"&cuLat="+this.currentUserLatitude,{ headers });
  }

  returnMasterPack():Observable<IMasterPackage>{
    let headers = new HttpHeaders().set('Authorization', 'auth-token');
    return this.http.get<IMasterPackage>("http://127.0.0.1:5153/api/MasterPackage?cuLon="+this.currentUserLongitude+"&cuLat="+this.currentUserLatitude,{ headers });
  }
  Everything:IMasterPackage[]|any=[];

  //Everything2:IMasterPackage = this.returnMasterPack();
  
  getMasterData(){     
    let url = "http://127.0.0.1:5153/api/MasterPackage?cuLon="+this.currentUserLongitude+"&cuLat="+this.currentUserLatitude;
    //console.log("getData() -pracuje");
    this.http.get(url).subscribe(response=>{
      //console.warn(data);
      this.Everything=response;
      
    });
  }
*/
  /*testApicall(){
    let headers = new HttpHeaders().set('Authorization', 'auth-token');
    this.posts = this.http.get("http://127.0.0.1:5153/api/GetClosest?cuLon="+this.currentUserLongitude+"&cuLat="+this.currentUserLatitude,{ headers });
    console.warn(this.posts);

    this.posts.array.forEach((element: { Id: any; lat: any; lon: any; Question: any; Answer: any; IsDone: any; Correct: any; Range: any; }) => {
      let tmp:IQuest={
        Id: element.Id,
        lat: element.lat,
        lon: element.lon,
        Question:element.Question,
        Answer:element.Answer,
        IsDone:element.IsDone,
        Correct:element.Correct,
        Range:element.Range,
      }
      this.testcopyfromjson=tmp;
    });
    console.log(this.testcopyfromjson.Id)
    
  }*/




