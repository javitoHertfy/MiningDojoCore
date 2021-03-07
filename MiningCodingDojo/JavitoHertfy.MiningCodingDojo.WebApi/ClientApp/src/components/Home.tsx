import * as React from 'react';
import { connect } from 'react-redux';

const Home = () => (
  <div>
    <h1>Mining Rules and Advice</h1>
    <p>Welcome to our annual competition for API consumers:</p>
    <ul>
      <li> Code as fast as you can, the miner with more gold in his/her pocket wins</li>
      <li> Visit Swagger page to know about endpoints and contracts </li>
      <li> Be careful! The API is bad implemented and throws a lot of random errors</li>
    </ul>
    <p>To help you get started:</p>
    <ul>
      <li>Create a Miner</li>
      <li>Sign Up into the mine</li>
      <li>Dig into the mine</li>
      <li>Save the gold in your miner's pocket</li>
    </ul>  
  </div>
);

export default connect()(Home);
