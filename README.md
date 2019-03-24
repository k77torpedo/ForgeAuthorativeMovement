# Just uploaded: Description is coming :)

# What it is
This is an authorative movement example for Forge Networking Remastered where players can freely move and jump inside the game without lag or rubber-banding until the player deviates from the server and is corrected - also known as "Server Reconciliation". This is a pattern that allows a client to have more crisp and lag-free movement than just interpolating to the players current position on the server. The player is thus always further than the server and everybody else.

This example also supports actions like jumping, weapon-attacks and the casting of skills to be reconciliated by the server.

# How it works

# Additional Remarks and Ideas
### Limiting Deviation
Limiting how far the player can be further than the server is usually a good idea. Set yourself a target like "The player is allowed to be 250 frames further than the server". This can be easily achieved by modifying the `InputListenerPlayer` as follows:
```
if (_isOwner && (_listener.CurrentFrame - _listener.AuthorativeFrame) < 250) {
    _listener.SaveFrame();
}
```
When the player is 250 frames ahead of the server he can't send any more inputs, move or take any action before the network stabilizes again. Try it out!

### Interpolation
If you want the example to look more smoothly you can turn on interpolation for `networkObject.position` in the Network Contract Wizard (NCF) of Forge Networking Remastered. This will result in reducing stutter when players see each other move.


# MIT License
Copyright (c) 2019 k77torpedo

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
