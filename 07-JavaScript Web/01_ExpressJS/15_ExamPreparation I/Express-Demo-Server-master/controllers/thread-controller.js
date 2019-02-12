const User = require('../models/User');
const Thread = require('../models/Thread');
const Message = require('../models/Message');
const isImageUrl = require('is-image-url');

module.exports = {
    searchThreadPost: async (req, res) => {
        try {
            const receiverUsername = req.body.username;

            if (!receiverUsername) {
                throw new Error("Receiver username is required!");
            }

            const receiverUser = await User.findOne({
                username: receiverUsername
            });

            if (!receiverUser) {
                throw new Error("Receiver not found!");
            }

            const users = [req.user._id, receiverUser._id];

            let thread = await Thread.findOne({
                users: {
                    $all: users
                }
            });

            if (!thread) {
                thread = await Thread.create({
                    users
                });
            }

            res.redirect(`/threads/${receiverUser.id}`);
        } catch (err) {
            // TODO: show error
            res.redirect('/');
            return;
        }
    },
    threadGet: async (req, res) => {
        try {
            const receiverId = req.params.receiverId;

            const receiver = await User.findById(receiverId);
            if (!receiver) {
                throw new Error("Receiver not found!");
            }

            const thread = await Thread.findOne({
                users: {
                    $all: [req.user._id, receiver._id]
                }
            });

            if (!thread) {
                throw new Error(`Thread not found!'`);
            }

            const regPattern = /https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)/g;

            let messages = await Message
                .find({
                    thread: thread.id
                });

            messages.forEach(message => {
                message.isMine = message.userReceiver.toString() !== req.user.id ? 'right' : 'left';

                let match = message.content.match(regPattern)
                if (match) {
                    for (let i = 0; i < match.length; i++) {
                        let url = match[i];

                        if (isImageUrl(url)) {
                            if (!message.images) {
                                message.images = [];
                            }
                            message.images.push(url)
                        }

                        message.content = message.content.replace(url, `<a target="_blank" rel="noopener noreferrer" href="${url}">${url}</a>`);
                    }
                }
            });

            res.render('chatroom/index', {
                messages,
                amIBlocked: receiver.blockedUsers.includes(req.user.username),
                isReceiverBlocked: req.user.blockedUsers.includes(receiver.username),
                receiver: {
                    id: receiver.id,
                    username: receiver.username,
                },
                threadId: thread.id,
            });
        } catch (err) {
            // TODO: show error
            console.log(err);
            res.redirect('/');
            return;
        }
    },
    sendMessage: async (req, res) => {
        try {
            const receiverId = req.params.receiverId;

            const receiver = await User.findById(receiverId);

            if (!receiver) {
                throw new Error('Receiver not found!');
            }

            if (receiver.blockedUsers.includes(req.user.username)) {
                throw new Error('You are blocked and can`t send messages!');
            }

            const threadId = req.body.threadId;
            const message = req.body.message;

            if (!message || !receiverId || !threadId) {
                throw new Error('Something went wrong!');
            }

            await Message.create({
                content: message,
                userReceiver: receiverId,
                thread: threadId
            });

            res.redirect(`/threads/${receiverId}`);
        } catch (err) {
            // TODO: show error
            res.redirect('/');
            return;
        }
    },
    deleteThread: async (req, res) => {
        try {
            const threadId = req.params.threadId;

            await Thread.findByIdAndRemove(threadId);
            await Message.deleteMany({
                thread: threadId
            });

            res.redirect('/');
        } catch (err) {
            // TODO: show error
            res.redirect('/');
            return;
        }
    },
};