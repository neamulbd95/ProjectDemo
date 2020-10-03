import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-viewPost',
  templateUrl: './viewPost.component.html',
  styleUrls: ['./viewPost.component.scss']
})
export class ViewPostComponent implements OnInit {
 values: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
  }
 getPosts(){
   this.http.get('http://localhost:5030/api/Post/ShowAllThePost').subscribe(response => {
     this.values = response;
   }, error =>{
      console.log(error);
   }
   );
 }
}
