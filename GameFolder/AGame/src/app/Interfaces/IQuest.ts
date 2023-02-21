export interface IQuest {
    id: number,
    lat: number,
    lon: number,
    question:string,
    answer:boolean,
    isDone:boolean,
    correct:boolean,
    range:number,
}